using JetBrains.Annotations;
using System.Threading.Tasks;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Modularity
{
    public interface IModuleLifecycleContributor : ITransientDependency
    {
        Task InitializeAsync([NotNull] ApplicationInitializationContext context, [NotNull] IAppModule module);

        void Initialize([NotNull] ApplicationInitializationContext context, [NotNull] IAppModule module);

        Task ShutdownAsync([NotNull] ApplicationShutdownContext context, [NotNull] IAppModule module);

        void Shutdown([NotNull] ApplicationShutdownContext context, [NotNull] IAppModule module);
    }
}

