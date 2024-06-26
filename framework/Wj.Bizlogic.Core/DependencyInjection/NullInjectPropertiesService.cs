﻿namespace Wj.Bizlogic.DependencyInjection
{
    public class NullInjectPropertiesService : IInjectPropertiesService, ITransientDependency
    {
        public TService InjectProperties<TService>(TService instance)
            where TService : notnull
        {
            return instance;
        }

        public TService InjectUnsetProperties<TService>(TService instance)
            where TService : notnull
        {
            return instance;
        }
    }
}

