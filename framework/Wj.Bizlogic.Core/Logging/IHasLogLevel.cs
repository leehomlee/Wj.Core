using Microsoft.Extensions.Logging;

namespace Wj.Bizlogic.Logging
{
    public interface IHasLogLevel
    {
        /// <summary>
        /// Log severity.
        /// </summary>
        LogLevel LogLevel { get; set; }
    }
}

