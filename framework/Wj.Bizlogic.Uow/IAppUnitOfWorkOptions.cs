using System.Data;

namespace Wj.Bizlogic.Uow
{
    public interface IAppUnitOfWorkOptions
    {
        bool IsTransactional { get; }

        IsolationLevel? IsolationLevel { get; }

        /// <summary>
        /// Milliseconds
        /// </summary>
        int? Timeout { get; }
    }
}

