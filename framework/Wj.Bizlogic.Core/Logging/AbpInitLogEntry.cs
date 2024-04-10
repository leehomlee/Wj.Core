using Microsoft.Extensions.Logging;
using System;

namespace Wj.Bizlogic.Logging
{
    public class AppInitLogEntry
    {
        public LogLevel LogLevel { get; set; }

        public EventId EventId { get; set; }

        public object State { get; set; } = default!;

        public Exception? Exception { get; set; }

        public Func<object, Exception?, string> Formatter { get; set; } = default!;

        public string Message => Formatter(State, Exception);
    }
}

