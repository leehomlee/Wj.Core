namespace Wj.Bizlogic.Uow
{
    public interface ISupportsRollback
    {
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}

