using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic
{
    public interface IOnApplicationShutdown
    {
        Task OnApplicationShutdownAsync([NotNull] ApplicationShutdownContext context);

        void OnApplicationShutdown([NotNull] ApplicationShutdownContext context);
    }
}
