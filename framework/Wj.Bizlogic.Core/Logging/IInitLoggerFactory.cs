﻿namespace Wj.Bizlogic.Logging
{
    public interface IInitLoggerFactory
    {
        IInitLogger<T> Create<T>();
    }
}

