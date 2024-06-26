﻿using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Wj.Bizlogic.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionDynamicOptionsManagerExtensions
    {
        public static IServiceCollection AddAppDynamicOptions<TOptions, TManager>(this IServiceCollection services)
            where TOptions : class
            where TManager : AppDynamicOptionsManager<TOptions>
        {
            services.Replace(ServiceDescriptor.Scoped(typeof(IOptions<TOptions>), typeof(TManager)));
            services.Replace(ServiceDescriptor.Scoped(typeof(IOptionsSnapshot<TOptions>), typeof(TManager)));

            return services;
        }
    }
}

