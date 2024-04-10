﻿using System.Threading.Tasks;

namespace Wj.Bizlogic.SimpleStateChecking
{
    public interface ISimpleBatchStateChecker<TState> : ISimpleStateChecker<TState> where TState : IHasSimpleStateCheckers<TState>
    {
        Task<SimpleStateCheckerResult<TState>> IsEnabledAsync(SimpleBatchStateCheckerContext<TState> context);
    }
}

