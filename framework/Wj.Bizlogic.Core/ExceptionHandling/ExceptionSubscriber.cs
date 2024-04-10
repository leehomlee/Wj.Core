using System.Threading.Tasks;
using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.ExceptionHandling
{
    [ExposeServices(typeof(IExceptionSubscriber))]
    public abstract class ExceptionSubscriber : IExceptionSubscriber, ITransientDependency
    {
        public abstract Task HandleAsync(ExceptionNotificationContext context);
    }
}

