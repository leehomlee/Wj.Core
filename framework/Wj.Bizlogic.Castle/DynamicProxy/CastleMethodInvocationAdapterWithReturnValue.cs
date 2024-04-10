using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.Castle.DynamicProxy
{
    public class CastleMethodInvocationAdapterWithReturnValue<TResult> : CastleMethodInvocationAdapterBase, IAppMethodInvocation
    {
        protected IInvocationProceedInfo ProceedInfo { get; }
        protected Func<IInvocation, IInvocationProceedInfo, Task<TResult>> Proceed { get; }

        public CastleMethodInvocationAdapterWithReturnValue(IInvocation invocation,
            IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
            : base(invocation)
        {
            ProceedInfo = proceedInfo;
            Proceed = proceed;
        }

        public override async Task ProceedAsync()
        {
            ReturnValue = (await Proceed(Invocation, ProceedInfo))!;
        }
    }
}

