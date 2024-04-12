namespace Wj.Bizlogic.Uow
{
    public interface IUnitOfWorkManagerAccessor
    {
        IUnitOfWorkManager UnitOfWorkManager { get; }
    }
}

