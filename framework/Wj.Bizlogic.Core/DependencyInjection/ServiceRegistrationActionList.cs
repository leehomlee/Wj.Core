using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.DependencyInjection
{
    public class ServiceRegistrationActionList : List<Action<IOnServiceRegistredContext>>
    {
        public bool IsClassInterceptorsDisabled { get; set; }
    }
}

