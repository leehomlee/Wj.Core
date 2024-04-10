using Microsoft.Extensions.Logging;

namespace Wj.Bizlogic.Logging
{
    public interface IExceptionWithSelfLogging
    {
        void Log(ILogger logger);
    }
}

