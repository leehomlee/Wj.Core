using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Wj.Bizlogic.Logging;
using Wj.Bizlogic.Modularity;
using Wj.Bizlogic.Reflection;
using Wj.Bizlogic.SimpleStateChecking;

namespace Wj.Bizlogic.Internal
{
    internal static class InternalServiceCollectionExtensions
    {
        internal static void AddCoreServices(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddLogging();
            services.AddLocalization();
        }

        internal static void AddCoreAppServices(this IServiceCollection services,
            IAppApplication appApplication,
            AppApplicationCreationOptions applicationCreationOptions)
        {
            var moduleLoader = new ModuleLoader();
            var assemblyFinder = new AssemblyFinder(appApplication);
            var typeFinder = new TypeFinder(assemblyFinder);

            if (!services.IsAdded<IConfiguration>())
            {
                services.ReplaceConfiguration(
                    ConfigurationHelper.BuildConfiguration(
                        applicationCreationOptions.Configuration
                    )
                );
            }

            services.TryAddSingleton<IModuleLoader>(moduleLoader);
            services.TryAddSingleton<IAssemblyFinder>(assemblyFinder);
            services.TryAddSingleton<ITypeFinder>(typeFinder);
            services.TryAddSingleton<IInitLoggerFactory>(new DefaultInitLoggerFactory());

            services.AddAssemblyOf<IAppApplication>();

            services.AddTransient(typeof(ISimpleStateCheckerManager<>), typeof(SimpleStateCheckerManager<>));

            services.Configure<AppModuleLifecycleOptions>(options =>
            {
                options.Contributors.Add<OnPreApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnPostApplicationInitializationModuleLifecycleContributor>();
                options.Contributors.Add<OnApplicationShutdownModuleLifecycleContributor>();
            });
        }
    }
}

