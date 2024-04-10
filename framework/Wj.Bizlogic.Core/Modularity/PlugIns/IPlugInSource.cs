using JetBrains.Annotations;
using System;

namespace Wj.Bizlogic.Modularity.PlugIns
{
    public interface IPlugInSource
    {
        [NotNull]
        Type[] GetModules();
    }
}

