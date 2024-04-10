using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Wj.Bizlogic.DependencyInjection
{
    public class ServiceActivatedActionList : List<KeyValuePair<ServiceDescriptor, Action<IOnServiceActivatedContext>>>
    {
        public List<Action<IOnServiceActivatedContext>> GetActions(ServiceDescriptor descriptor)
        {
            return this.Where(x => x.Key == descriptor).Select(x => x.Value).ToList();
        }
    }
}

