﻿using JetBrains.Annotations;

namespace Wj.Bizlogic.Uow
{
    public class UnitOfWorkEventArgs : EventArgs
    {
        /// <summary>
        /// Reference to the unit of work related to this event.
        /// </summary>
        public IUnitOfWork UnitOfWork { get; }

        public UnitOfWorkEventArgs([NotNull] IUnitOfWork unitOfWork)
        {
            Check.NotNull(unitOfWork, nameof(unitOfWork));

            UnitOfWork = unitOfWork;
        }
    }
}

