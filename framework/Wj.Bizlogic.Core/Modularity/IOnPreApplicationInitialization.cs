using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public interface IOnPreApplicationInitialization
    {
        Task OnPreApplicationInitializationAsync([NotNull] ApplicationInitializationContext context);

        void OnPreApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
