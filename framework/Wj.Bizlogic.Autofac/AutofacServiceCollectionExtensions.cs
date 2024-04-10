using Autofac;
using System;
using Wj.Bizlogic;
using Wj.Bizlogic.Autofac;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AutofacServiceCollectionExtensions
    {
        public static ContainerBuilder GetContainerBuilder(this IServiceCollection services)
        {
            Check.NotNull(services, nameof(services));

            var builder = services.GetObjectOrNull<ContainerBuilder>();
            if (builder == null)
            {
                throw new AppException($"Could not find ContainerBuilder. Be sure that you have called {nameof(UseAutofac)} method before!");
            }

            return builder;
        }

        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services, Action<ContainerBuilder>? builderAction = null)
        {
            return services.BuildServiceProviderFromFactory(builderAction);
        }

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

