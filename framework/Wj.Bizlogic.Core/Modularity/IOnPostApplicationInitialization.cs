using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic.Modularity
{
    public interface IOnPostApplicationInitialization
    {
        Task OnPostApplicationInitializationAsync([NotNull] ApplicationInitializationContext context);

        void OnPostApplicationInitialization([NotNull] ApplicationInitializationContext context);
    }
}
