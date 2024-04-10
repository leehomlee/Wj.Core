using Castle.DynamicProxy;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.Castle.DynamicProxy
{
    public class AppAsyncDeterminationInterceptor<TInterceptor> : AsyncDeterminationInterceptor
        where TInterceptor : IAppInterceptor
    {
        public AppAsyncDeterminationInterceptor(TInterceptor appInterceptor)
        : base(new CastleAsyncInterceptorAdapter<TInterceptor>(appInterceptor))
        {

        }
    }
}

