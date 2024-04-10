using JetBrains.Annotations;
using System;
using Wj.Bizlogic.Collections;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.DependencyInjection
{
    public class OnServiceRegistredContext : IOnServiceRegistredContext
    {
        public virtual ITypeList<IAppInterceptor> Interceptors { get; }

        public virtual Type ServiceType { get; }

        public virtual Type ImplementationType { get; }

        public OnServiceRegistredContext(Type serviceType, [NotNull] Type implementationType)
        {
            ServiceType = Check.NotNull(serviceType, nameof(serviceType));
            ImplementationType = Check.NotNull(implementationType, nameof(implementationType));

            Interceptors = new TypeList<IAppInterceptor>();
        }
    }
}

