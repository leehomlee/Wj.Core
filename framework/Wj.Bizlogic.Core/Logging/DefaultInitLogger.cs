using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Wj.Bizlogic.Logging
{
    public class DefaultInitLogger<T> : IInitLogger<T>
    {
        public List<AppInitLogEntry> Entries { get; }

        public DefaultInitLogger()
        {
            Entries = new List<AppInitLogEntry>();
        }

        public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Entries.Add(new AppInitLogEntry
            {
                LogLevel = logLevel,
                EventId = eventId,
                State = state!,
                Exception = exception,
                Formatter = (s, e) => formatter((TState)s, e),
            });
        }

        public virtual bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.None;
        }

        public virtual IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return NullDisposable.Instance;
        }
    }
}

