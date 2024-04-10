using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public abstract class ModuleLifecycleContributorBase : IModuleLifecycleContributor
    {
        public virtual Task InitializeAsync(ApplicationInitializationContext context, IAppModule module)
        {
            return Task.CompletedTask;
        }

        public virtual void Initialize(ApplicationInitializationContext context, IAppModule module)
        {
        }

        public virtual Task ShutdownAsync(ApplicationShutdownContext context, IAppModule module)
        {
            return Task.CompletedTask;
        }

        public virtual void Shutdown(ApplicationShutdownContext context, IAppModule module)
        {
        }
    }
}

