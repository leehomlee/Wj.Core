using Wj.Bizlogic.Collections;

namespace Wj.Bizlogic.Modularity
{
    public class AppModuleLifecycleOptions
    {
        public ITypeList<IModuleLifecycleContributor> Contributors { get; }

        public AppModuleLifecycleOptions()
        {
            Contributors = new TypeList<IModuleLifecycleContributor>();
        }
    }
}

