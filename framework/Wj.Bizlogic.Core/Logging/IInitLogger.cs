using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Wj.Bizlogic.Logging
{
    public interface IInitLogger<out T> : ILogger<T>
    {
        public List<AppInitLogEntry> Entries { get; }
    }
}

