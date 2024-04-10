using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wj.Bizlogic.DependencyInjection;
using Wj.Bizlogic.Internal;
using Wj.Bizlogic.Logging;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic
{
    public abstract class AppApplicationBase : IAppApplication
    {
        [NotNull]
        public Type StartupModuleType { get; }

        public IServiceProvider ServiceProvider { get; private set; } = default!;

        public IServiceCollection Services { get; }

        public IReadOnlyList<IAppModuleDescriptor> Modules { get; }

        public string? ApplicationName { get; }

        public string InstanceId { get; } = Guid.NewGuid().ToString();

        private bool _configuredServices;

        internal AppApplicationBase([NotNull] Type startupModuleType, [NotNull] IServiceCollection services, Action<AppApplicationCreationOptions>? optionsAction)
        {
            Check.NotNull(startupModuleType, nameof(startupModuleType));
            Check.NotNull(services, nameof(services));

            StartupModuleType = startupModuleType;
            Services = services;

            services.TryAddObjectAccessor<IServiceProvider>();

            var options = new AppApplicationCreationOptions(services);
            optionsAction?.Invoke(options);

            ApplicationName = GetApplicationName(options);

            services.AddSingleton<IAppApplication>(this);
            services.AddSingleton<IApplicationInfoAccessor>(this);
            services.AddSingleton<IModuleContainer>(this);
            services.AddSingleton<IAppHostEnvironment>(new AppHostEnvironment()
            {
                EnvironmentName = options.Environment
            });

            services.AddCoreServices();
            services.AddCoreAppServices(this, options);

            Modules = LoadModules(services, options);

            if (!options.SkipConfigureServices)
            {
                ConfigureServices();
            }
        }

        public virtual async Task ShutdownAsync()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                await scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .ShutdownModulesAsync(new ApplicationShutdownContext(scope.ServiceProvider));
            }
        }

        public virtual void Shutdown()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .ShutdownModules(new ApplicationShutdownContext(scope.ServiceProvider));
            }
        }

        public virtual void Dispose()
        {
            //TODO: Shutdown if not done before?
        }

        protected virtual void SetServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
            ServiceProvider.GetRequiredService<ObjectAccessor<IServiceProvider>>().Value = ServiceProvider;
        }

        protected virtual async Task InitializeModulesAsync()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                WriteInitLogs(scope.ServiceProvider);
                await scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .InitializeModulesAsync(new ApplicationInitializationContext(scope.ServiceProvider));
            }
        }

        protected virtual void InitializeModules()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                WriteInitLogs(scope.ServiceProvider);
                scope.ServiceProvider
                    .GetRequiredService<IModuleManager>()
                    .InitializeModules(new ApplicationInitializationContext(scope.ServiceProvider));
            }
        }

        protected virtual void WriteInitLogs(IServiceProvider serviceProvider)
        {
            var logger = serviceProvider.GetService<ILogger<AppApplicationBase>>();
            if (logger == null)
            {
                return;
            }

            var initLogger = serviceProvider.GetRequiredService<IInitLoggerFactory>().Create<AppApplicationBase>();

            foreach (var entry in initLogger.Entries)
            {
                logger.Log(entry.LogLevel, entry.EventId, entry.State, entry.Exception, entry.Formatter);
            }

            initLogger.Entries.Clear();
        }


        protected virtual IReadOnlyList<IAppModuleDescriptor> LoadModules(IServiceCollection services, AppApplicationCreationOptions options)
        {
            return services
                .GetSingletonInstance<IModuleLoader>()
                .LoadModules(
                    services,
                    StartupModuleType,
                    options.PlugInSources
                );
        }

        public virtual async Task ConfigureServicesAsync()
        {
            CheckMultipleConfigureServices();

            var context = new ServiceConfigurationContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is AppModule appModule)
                {
                    appModule.ServiceConfigurationContext = context;
                }
            }

            //PreConfigureServices
            foreach (var module in Modules.Where(m => m.Instance is IPreConfigureServices))
            {
                try
                {
                    await ((IPreConfigureServices)module.Instance).PreConfigureServicesAsync(context);
                }
                catch (Exception ex)
                {
                    throw new AppInitializationException($"An error occurred during {nameof(IPreConfigureServices.PreConfigureServicesAsync)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.", ex);
                }
            }

            var assemblies = new HashSet<Assembly>();

            //ConfigureServices
            foreach (var module in Modules)
            {
                if (module.Instance is AppModule abpModule)
                {
                    if (!abpModule.SkipAutoServiceRegistration)
                    {
                        foreach (var assembly in module.AllAssemblies)
                        {
                            if (!assemblies.Contains(assembly))
                            {
                                Services.AddAssembly(assembly);
                                assemblies.Add(assembly);
                            }
                        }
                    }
                }

                try
                {
                    await module.Instance.ConfigureServicesAsync(context);
                }
                catch (Exception ex)
                {
                    throw new AppInitializationException($"An error occurred during {nameof(IAppModule.ConfigureServicesAsync)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.", ex);
                }
            }

            //PostConfigureServices
            foreach (var module in Modules.Where(m => m.Instance is IPostConfigureServices))
            {
                try
                {
                    await ((IPostConfigureServices)module.Instance).PostConfigureServicesAsync(context);
                }
                catch (Exception ex)
                {
                    throw new AppInitializationException($"An error occurred during {nameof(IPostConfigureServices.PostConfigureServicesAsync)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.", ex);
                }
            }

            foreach (var module in Modules)
            {
                if (module.Instance is AppModule abpModule)
                {
                    abpModule.ServiceConfigurationContext = null!;
                }
            }

            _configuredServices = true;

            TryToSetEnvironment(Services);
        }

        private void CheckMultipleConfigureServices()
        {
            if (_configuredServices)
            {
                throw new AppInitializationException("Services have already been configured! If you call ConfigureServicesAsync method, you must have set AbpApplicationCreationOptions.SkipConfigureServices to true before.");
            }
        }

        //TODO: We can extract a new class for this
        public virtual void ConfigureServices()
        {
            CheckMultipleConfigureServices();

            var context = new ServiceConfigurationContext(Services);
            Services.AddSingleton(context);

            foreach (var module in Modules)
            {
                if (module.Instance is AppModule abpModule)
                {
                    abpModule.ServiceConfigurationContext = context;
                }
            }

            //PreConfigureServices
            foreach (var module in Modules.Where(m => m.Instance is IPreConfigureServices))
            {
                try
                {
                    ((IPreConfigureServices)module.Instance).PreConfigureServices(context);
                }
                catch (Exception ex)
                {
                    throw new AppInitializationException($"An error occurred during {nameof(IPreConfigureServices.PreConfigureServices)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.", ex);
                }
            }

            var assemblies = new HashSet<Assembly>();

            //ConfigureServices
            foreach (var module in Modules)
            {
                if (module.Instance is AppModule abpModule)
                {
                    if (!abpModule.SkipAutoServiceRegistration)
                    {
                        foreach (var assembly in module.AllAssemblies)
                        {
                            if (!assemblies.Contains(assembly))
                            {
                                Services.AddAssembly(assembly);
                                assemblies.Add(assembly);
                            }
                        }
                    }
                }

                try
                {
                    module.Instance.ConfigureServices(context);
                }
                catch (Exception ex)
                {
                    throw new AppInitializationException($"An error occurred during {nameof(IAppModule.ConfigureServices)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.", ex);
                }
            }

            //PostConfigureServices
            foreach (var module in Modules.Where(m => m.Instance is IPostConfigureServices))
            {
                try
                {
                    ((IPostConfigureServices)module.Instance).PostConfigureServices(context);
                }
                catch (Exception ex)
                {
                    throw new AppInitializationException($"An error occurred during {nameof(IPostConfigureServices.PostConfigureServices)} phase of the module {module.Type.AssemblyQualifiedName}. See the inner exception for details.", ex);
                }
            }

            foreach (var module in Modules)
            {
                if (module.Instance is AppModule abpModule)
                {
                    abpModule.ServiceConfigurationContext = null!;
                }
            }

            _configuredServices = true;

            TryToSetEnvironment(Services);
        }

        private static string? GetApplicationName(AppApplicationCreationOptions options)
        {
            if (!string.IsNullOrWhiteSpace(options.ApplicationName))
            {
                return options.ApplicationName!;
            }

            var configuration = options.Services.GetConfigurationOrNull();
            if (configuration != null)
            {
                var appNameConfig = configuration["ApplicationName"];
                if (!string.IsNullOrWhiteSpace(appNameConfig))
                {
                    return appNameConfig!;
                }
            }

            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                return entryAssembly.GetName().Name;
            }

            return null;
        }

        private static void TryToSetEnvironment(IServiceCollection services)
        {
            var abpHostEnvironment = services.GetSingletonInstance<IAppHostEnvironment>();
            if (abpHostEnvironment.EnvironmentName.IsNullOrWhiteSpace())
            {
                abpHostEnvironment.EnvironmentName = Environments.Production;
            }
        }
    }
}

