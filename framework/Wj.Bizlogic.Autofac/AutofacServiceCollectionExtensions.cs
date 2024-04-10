using Autofac;
using System;
using Wj.Bizlogic;

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
                throw new AppException($"Could not find ContainerBuilder. Be sure that you have called {nameof(AutofacAppApplicationCreationOptionsExtensions.UseAutofac)} method before!");
            }

            return builder;
        }

        public static IServiceProvider BuildAutofacServiceProvider(this IServiceCollection services, Action<ContainerBuilder>? builderAction = null)
        {
            return services.BuildServiceProviderFromFactory(builderAction);
        }
    }
}

