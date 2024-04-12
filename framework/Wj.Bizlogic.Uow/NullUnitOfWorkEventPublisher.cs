using Wj.Bizlogic.DependencyInjection;

namespace Wj.Bizlogic.Uow
{
    public class NullUnitOfWorkEventPublisher : IUnitOfWorkEventPublisher, ISingletonDependency
    {
        public Task PublishLocalEventsAsync(IEnumerable<UnitOfWorkEventRecord> localEvents)
        {
            return Task.CompletedTask;
        }

        public Task PublishDistributedEventsAsync(IEnumerable<UnitOfWorkEventRecord> distributedEvents)
        {
            return Task.CompletedTask;
        }
    }
}

