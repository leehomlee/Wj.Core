using JetBrains.Annotations;
using System;

namespace Wj.Bizlogic.Modularity
{
    public interface IDependedTypesProvider
    {
        [NotNull]
        Type[] GetDependedTypes();
    }
}

