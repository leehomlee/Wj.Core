using System.Collections.Generic;

namespace Wj.Bizlogic.SimpleStateChecking
{
    public interface IHasSimpleStateCheckers<TState> where TState : IHasSimpleStateCheckers<TState>
    {
        List<ISimpleStateChecker<TState>> StateCheckers { get; }
    }
}

