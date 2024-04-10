using Wj.Bizlogic.Collections;

namespace Wj.Bizlogic.SimpleStateChecking
{
    public class AppSimpleStateCheckerOptions<TState> where TState : IHasSimpleStateCheckers<TState>
    {
        public ITypeList<ISimpleStateChecker<TState>> GlobalStateCheckers { get; }

        public AppSimpleStateCheckerOptions()
        {
            GlobalStateCheckers = new TypeList<ISimpleStateChecker<TState>>();
        }
    }
}

