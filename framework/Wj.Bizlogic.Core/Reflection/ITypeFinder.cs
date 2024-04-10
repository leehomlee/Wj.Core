using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.Reflection
{
    public interface ITypeFinder
    {
        IReadOnlyList<Type> Types { get; }
    }
}

