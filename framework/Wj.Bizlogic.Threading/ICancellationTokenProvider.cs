namespace Wj.Bizlogic.Threading
{
    public interface ICancellationTokenProvider
    {
        CancellationToken Token { get; }

        IDisposable Use(CancellationToken cancellationToken);
    }
}

