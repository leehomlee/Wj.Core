﻿using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Wj.Bizlogic.Autofac;

namespace Microsoft.Extensions.Hosting
{
    public static class AutofacHostBuilderExtensions
    {
        public static IHostBuilder UseAutofac(this IHostBuilder hostBuilder)
        {
            var containerBuilder = new ContainerBuilder();

            return hostBuilder.ConfigureServices((_, services) =>
            {
                services.AddObjectAccessor(containerBuilder);
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(containerBuilder));
        }
    }
}

