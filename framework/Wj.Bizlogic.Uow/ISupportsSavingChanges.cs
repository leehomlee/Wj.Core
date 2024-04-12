namespace Wj.Bizlogic.Uow
{
    public interface ISupportsSavingChanges
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

