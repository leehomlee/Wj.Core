using JetBrains.Annotations;
using System;
using System.Threading.Tasks;
using Wj.Bizlogic;
using Wj.Bizlogic.Modularity;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionApplicationExtensions
    {
        public static IAppApplicationWithExternalServiceProvider AddApplication<TStartupModule>(
        [NotNull] this IServiceCollection services,
        Action<AppApplicationCreationOptions>? optionsAction = null)
        where TStartupModule : IAppModule
        {
            return AppApplicationFactory.Create<TStartupModule>(services, optionsAction);
        }

        public static IAppApplicationWithExternalServiceProvider AddApplication(
            [NotNull] this IServiceCollection services,
            [NotNull] Type startupModuleType,
            Action<AppApplicationCreationOptions>? optionsAction = null)
        {
            return AppApplicationFactory.Create(startupModuleType, services, optionsAction);
        }

        public async static Task<IAppApplicationWithExternalServiceProvider> AddApplicationAsync<TStartupModule>(
            [NotNull] this IServiceCollection services,
            Action<AppApplicationCreationOptions>? optionsAction = null)
            where TStartupModule : IAppModule
        {
            return await AppApplicationFactory.CreateAsync<TStartupModule>(services, optionsAction);
        }

        public async static Task<IAppApplicationWithExternalServiceProvider> AddApplicationAsync(
            [NotNull] this IServiceCollection services,
            [NotNull] Type startupModuleType,
            Action<AppApplicationCreationOptions>? optionsAction = null)
        {
            return await AppApplicationFactory.CreateAsync(startupModuleType, services, optionsAction);
        }

        public static string? GetApplicationName(this IServiceCollection services)
        {
            return services.GetSingletonInstance<IApplicationInfoAccessor>().ApplicationName;
        }

        [NotNull]
        public static string GetApplicationInstanceId(this IServiceCollection services)
        {
            return services.GetSingletonInstance<IApplicationInfoAccessor>().InstanceId;
        }

        [NotNull]
        public static IAppHostEnvironment GetAbpHostEnvironment(this IServiceCollection services)
        {
            return services.GetSingletonInstance<IAppHostEnvironment>();
        }
    }
}

