using System.Threading.Tasks;

namespace Wj.Bizlogic.DynamicProxy
{
    public interface IAppInterceptor
    {
        Task InterceptAsync(IAppMethodInvocation invocation);
    }
}

