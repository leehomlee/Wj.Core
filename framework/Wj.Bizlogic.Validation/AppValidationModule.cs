using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Modularity;

namespace Wj.Bizlogic.Validation
{
    [DependsOn(typeof(AppValidationAbstractionsModule))]
    public class AppValidationModule : AppModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.OnRegistered(ValidationInterceptorRegistrar.RegisterIfNeeded);
            AutoAddObjectValidationContributors(context.Services);
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            // 注册虚拟文件目录
            // 注册本地化文件资源

        }

        private static void AutoAddObjectValidationContributors(IServiceCollection services)
        {
            var contributorTypes = new List<Type>();

            services.OnRegistered(context =>
            {
                if (typeof(IObjectValidationContributor).IsAssignableFrom(context.ImplementationType))
                {
                    contributorTypes.Add(context.ImplementationType);
                }
            });

            services.Configure<AppValidationOptions>(options =>
            {
                options.ObjectValidationContributors.AddIfNotContains(contributorTypes);
            });
        }
    }
}

