﻿using Microsoft.Extensions.DependencyInjection;
using System;

namespace Wj.Bizlogic.DependencyInjection
{
    [ExposeServices(typeof(IRootServiceProvider))]
    public class RootServiceProvider : IRootServiceProvider, ISingletonDependency
    {
        protected IServiceProvider ServiceProvider { get; }

        public RootServiceProvider(IObjectAccessor<IServiceProvider> objectAccessor)
        {
            ServiceProvider = objectAccessor.Value!;
        }

        public virtual object? GetService(Type serviceType)
        {
            return ServiceProvider.GetService(serviceType);
        }

        public object? GetKeyedService(Type serviceType, object? serviceKey)
        {
            return ServiceProvider.GetKeyedService(serviceType, serviceKey);
        }

        public virtual object GetRequiredKeyedService(Type serviceType, object? serviceKey)
        {
            return ServiceProvider.GetRequiredKeyedService(serviceType, serviceKey);
        }
    }
}

