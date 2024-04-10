using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic;

public interface IOnApplicationInitialization
{
    Task OnApplicationInitializationAsync([NotNull] ApplicationInitializationContext context);

    void OnApplicationInitialization([NotNull] ApplicationInitializationContext context);
}
