using JetBrains.Annotations;
using System.Collections.Generic;

namespace Wj.Bizlogic.Modularity
{
    public interface IModuleContainer
    {
        [NotNull]
        IReadOnlyList<IAppModuleDescriptor> Modules { get; }
    }
}
