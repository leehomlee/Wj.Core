using System.Threading.Tasks;

namespace Wj.Bizlogic.DynamicProxy
{
    public abstract class AppInterceptor : IAppInterceptor
    {
        public abstract Task InterceptAsync(IAppMethodInvocation invocation);
    }
}

