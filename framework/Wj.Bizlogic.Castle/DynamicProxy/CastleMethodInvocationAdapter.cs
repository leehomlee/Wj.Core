﻿using Castle.DynamicProxy;
using System;
using System.Threading.Tasks;
using Wj.Bizlogic.DynamicProxy;

namespace Wj.Bizlogic.Castle.DynamicProxy
{
    public class CastleMethodInvocationAdapter : CastleMethodInvocationAdapterBase, IAppMethodInvocation
    {
        protected IInvocationProceedInfo ProceedInfo { get; }
        protected Func<IInvocation, IInvocationProceedInfo, Task> Proceed { get; }

        public CastleMethodInvocationAdapter(IInvocation invocation, IInvocationProceedInfo proceedInfo,
            Func<IInvocation, IInvocationProceedInfo, Task> proceed)
            : base(invocation)
        {
            ProceedInfo = proceedInfo;
            Proceed = proceed;
        }

        public override async Task ProceedAsync()
        {
            await Proceed(Invocation, ProceedInfo);
        }
    }
}

