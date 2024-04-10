using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Autofac;

namespace Wj.Bizlogic
{
    public static class AutofacAppApplicationCreationOptionsExtensions
    {
        public static void UseAutofac(this AppApplicationCreationOptions options)
        {
            options.Services.AddAutofacServiceProviderFactory();
        }

        public static AutofacServiceProviderFactory AddAutofacServiceProviderFactory(this IServiceCollection services)
        {
            return services.AddAutofacServiceProviderFactory(new ContainerBuilder());
        }

        public static AutofacServiceProviderFactory AddAutofacServiceProviderFactory(this IServiceCollection services, ContainerBuilder containerBuilder)
        {
            var factory = new AutofacServiceProviderFactory(containerBuilder);

            services.AddObjectAccessor(containerBuilder);
            services.AddSingleton((IServiceProviderFactory<ContainerBuilder>)factory);

            return factory;
        }
    }
}

