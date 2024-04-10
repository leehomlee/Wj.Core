using System.Collections.Generic;
using System.Reflection;

namespace Wj.Bizlogic.Reflection
{
    public interface IAssemblyFinder
    {
        IReadOnlyList<Assembly> Assemblies { get; }
    }
}

