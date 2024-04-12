namespace Wj.Bizlogic.Uow
{
    public interface IUnitOfWorkTransactionBehaviourProvider
    {
        bool? IsTransactional { get; }
    }
}

