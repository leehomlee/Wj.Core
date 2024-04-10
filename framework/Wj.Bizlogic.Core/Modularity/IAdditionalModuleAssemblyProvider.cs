using System.Reflection;

namespace Wj.Bizlogic.Modularity
{
    public interface IAdditionalModuleAssemblyProvider
    {
        Assembly[] GetAssemblies();
    }
}

