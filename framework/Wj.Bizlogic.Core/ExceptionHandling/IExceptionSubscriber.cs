using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic.ExceptionHandling
{
    public interface IExceptionSubscriber
    {
        Task HandleAsync([NotNull] ExceptionNotificationContext context);
    }
}

