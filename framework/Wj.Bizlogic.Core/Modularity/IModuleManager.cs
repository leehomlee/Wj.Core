using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public interface IModuleManager
    {
        Task InitializeModulesAsync([NotNull] ApplicationInitializationContext context);

        void InitializeModules([NotNull] ApplicationInitializationContext context);

        Task ShutdownModulesAsync([NotNull] ApplicationShutdownContext context);

        void ShutdownModules([NotNull] ApplicationShutdownContext context);
    }
}

