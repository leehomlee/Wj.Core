using System;
using Wj.Bizlogic.Collections;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.DependencyInjection
{
    public interface IOnServiceRegistredContext
    {
        ITypeList<IAppInterceptor> Interceptors { get; }

        Type ImplementationType { get; }
    }
}

