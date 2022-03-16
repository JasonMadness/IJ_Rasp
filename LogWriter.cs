using System;

namespace Rasp_Logger
{
    internal class LogWriter : ILogger
    {
        protected readonly ILogger Logger;

        public LogWriter(ILogger logger = null)
        {
            Logger = logger;
        }

        public virtual void WriteError(string message)
        {
            Logger?.WriteError(message);
        }
    }
}
