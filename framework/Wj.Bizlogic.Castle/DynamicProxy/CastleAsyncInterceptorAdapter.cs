using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.Castle.DynamicProxy
{
    public class CastleAsyncInterceptorAdapter<TInterceptor> : AsyncInterceptorBase
        where TInterceptor : IAppInterceptor
    {
        private readonly TInterceptor _appInterceptor;

        public CastleAsyncInterceptorAdapter(TInterceptor appInterceptor)
        {
            _appInterceptor = appInterceptor;
        }

        protected override async Task InterceptAsync(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task> proceed)
        {
            await _appInterceptor.InterceptAsync(
                new CastleMethodInvocationAdapter(invocation, proceedInfo, proceed)
            );
        }

        protected override async Task<TResult> InterceptAsync<TResult>(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
        {
            var adapter = new CastleMethodInvocationAdapterWithReturnValue<TResult>(invocation, proceedInfo, proceed);

            await _appInterceptor.InterceptAsync(
                adapter
            );

            return (TResult)adapter.ReturnValue;
        }
    }
}

