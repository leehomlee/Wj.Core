﻿using System;

namespace Wj.Bizlogic.DependencyInjection
{
    [ExposeServices(typeof(ITransientCachedServiceProvider))]
    public class TransientCachedServiceProvider : CachedServiceProviderBase, ITransientCachedServiceProvider, ITransientDependency
    {
        public TransientCachedServiceProvider(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
    }
}

