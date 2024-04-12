namespace Wj.Bizlogic.Uow
{
    public interface IUnitOfWorkEventPublisher
    {
        Task PublishLocalEventsAsync(IEnumerable<UnitOfWorkEventRecord> localEvents);

        Task PublishDistributedEventsAsync(IEnumerable<UnitOfWorkEventRecord> distributedEvents);
    }
}

