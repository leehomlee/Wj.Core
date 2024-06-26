﻿using JetBrains.Annotations;

namespace Wj.Bizlogic.Uow
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork? Current { get; }

        [NotNull]
        IUnitOfWork Begin([NotNull] AppUnitOfWorkOptions options, bool requiresNew = false);

        [NotNull]
        IUnitOfWork Reserve([NotNull] string reservationName, bool requiresNew = false);

        void BeginReserved([NotNull] string reservationName, [NotNull] AppUnitOfWorkOptions options);

        bool TryBeginReserved([NotNull] string reservationName, [NotNull] AppUnitOfWorkOptions options);
    }
}

