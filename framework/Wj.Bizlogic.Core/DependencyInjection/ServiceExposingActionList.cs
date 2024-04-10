using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.DependencyInjection
{
    public class ServiceExposingActionList : List<Action<IOnServiceExposingContext>>
    {
    }
}

