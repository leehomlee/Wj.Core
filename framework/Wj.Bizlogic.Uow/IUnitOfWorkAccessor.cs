namespace Wj.Bizlogic.Uow
{
    public interface IUnitOfWorkAccessor
    {
        IUnitOfWork? UnitOfWork { get; }

        void SetUnitOfWork(IUnitOfWork? unitOfWork);
    }
}

