namespace Wj.Bizlogic.Uow
{
    public interface ITransactionApi : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
    }
}

