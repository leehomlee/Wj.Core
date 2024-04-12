using JetBrains.Annotations;

namespace Wj.Bizlogic.Uow
{
    public interface ITransactionApiContainer
    {
        ITransactionApi? FindTransactionApi([NotNull] string key);

        void AddTransactionApi([NotNull] string key, [NotNull] ITransactionApi api);

        [NotNull]
        ITransactionApi GetOrAddTransactionApi([NotNull] string key, [NotNull] Func<ITransactionApi> factory);
    }
}

