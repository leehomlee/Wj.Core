using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.DependencyInjection
{
    public interface IOnServiceExposingContext
    {
        Type ImplementationType { get; }

        List<Type> ExposedTypes { get; }
    }
}

