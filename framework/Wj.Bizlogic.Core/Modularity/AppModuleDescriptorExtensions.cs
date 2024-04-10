using System;
using System.Linq;
using System.Reflection;

namespace Wj.Bizlogic.Modularity
{
    public static class AppModuleDescriptorExtensions
    {
        public static Assembly[] GetAdditionalAssemblies(this IAppModuleDescriptor module)
        {
            return module.AllAssemblies.Length <= 1
                ? Array.Empty<Assembly>()
                : module.AllAssemblies.Where(x => x != module.Assembly).ToArray();
        }
    }
}

