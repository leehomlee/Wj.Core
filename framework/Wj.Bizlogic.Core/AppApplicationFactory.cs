using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic
{
    public static class AppApplicationFactory
    {
        public async static Task<IAppApplicationWithInternalServiceProvider> CreateAsync<TStartupModule>(Action<AppApplicationCreationOptions>? optionsAction = null) where TStartupModule : IAppModule
        {
            var app = Create(typeof(TStartupModule), options =>
            {
                options.SkipConfigureServices = true;
                optionsAction?.Invoke(options);
            });
            await app.ConfigureServicesAsync();
            return app;
        }

        public async static Task<IAppApplicationWithInternalServiceProvider> CreateAsync(
            [NotNull] Type startupModuleType,
            Action<AppApplicationCreationOptions>? optionsAction = null)
        {
            var app = new AppApplicationWithInternalServiceProvider(startupModuleType, options =>
            {
                options.SkipConfigureServices = true;
                optionsAction?.Invoke(options);
            });
            await app.ConfigureServicesAsync();
            return app;
        }

        public async static Task<IAppApplicationWithExternalServiceProvider> CreateAsync<TStartupModule>(
            [NotNull] IServiceCollection services,
            Action<AppApplicationCreationOptions>? optionsAction = null)
            where TStartupModule : IAppModule
        {
            var app = Create(typeof(TStartupModule), services, options =>
            {
                options.SkipConfigureServices = true;
                optionsAction?.Invoke(options);
            });
            await app.ConfigureServicesAsync();
            return app;
        }

        public async static Task<IAppApplicationWithExternalServiceProvider> CreateAsync(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            Action<AppApplicationCreationOptions>? optionsAction = null)
        {
            var app = new AppApplicationWithExternalServiceProvider(startupModuleType, services, options =>
            {
                options.SkipConfigureServices = true;
                optionsAction?.Invoke(options);
            });
            await app.ConfigureServicesAsync();
            return app;
        }

        public static IAppApplicationWithInternalServiceProvider Create<TStartupModule>(
            Action<AppApplicationCreationOptions>? optionsAction = null)
            where TStartupModule : IAppModule
        {
            return Create(typeof(TStartupModule), optionsAction);
        }

        public static IAppApplicationWithInternalServiceProvider Create([NotNull] Type startupModuleType, Action<AppApplicationCreationOptions>? optionsAction = null)
        {
            return new AppApplicationWithInternalServiceProvider(startupModuleType, optionsAction);
        }

        public static IAppApplicationWithExternalServiceProvider Create<TStartupModule>(
            [NotNull] IServiceCollection services,
            Action<AppApplicationCreationOptions>? optionsAction = null)
            where TStartupModule : IAppModule
        {
            return Create(typeof(TStartupModule), services, optionsAction);
        }

        public static IAppApplicationWithExternalServiceProvider Create(
            [NotNull] Type startupModuleType,
            [NotNull] IServiceCollection services,
            Action<AppApplicationCreationOptions>? optionsAction = null)
        {
            return new AppApplicationWithExternalServiceProvider(startupModuleType, services, optionsAction);
        }
    }
}

