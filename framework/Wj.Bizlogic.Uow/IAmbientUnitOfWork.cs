namespace Wj.Bizlogic.Uow
{
    public interface IAmbientUnitOfWork : IUnitOfWorkAccessor
    {
        IUnitOfWork? GetCurrentByChecking();
    }
}

