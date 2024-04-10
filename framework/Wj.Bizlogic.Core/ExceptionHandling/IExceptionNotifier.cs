using JetBrains.Annotations;
using System.Threading.Tasks;

namespace Wj.Bizlogic.ExceptionHandling
{
    public interface IExceptionNotifier
    {
        Task NotifyAsync([NotNull] ExceptionNotificationContext context);
    }
}

