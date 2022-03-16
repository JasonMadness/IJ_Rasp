using System;

namespace Rasp_Logger
{
    internal class FridayLogWriter : LogWriter
    {
        public FridayLogWriter(ILogger logger) : base(logger)
        {
            if (logger == null)
                throw new ArgumentNullException(nameof(logger));
        }

        public override void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                base.WriteError(message);
            }
        }
    }
}
