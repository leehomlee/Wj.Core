using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Uow
{
    public class NullUnitOfWorkTransactionBehaviourProvider : IUnitOfWorkTransactionBehaviourProvider, ISingletonDependency
    {
        public bool? IsTransactional => null;
    }
}

