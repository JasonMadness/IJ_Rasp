using System;

namespace Rasp_Logger
{
    internal class ConsoleLogWriter : LogWriter
    {
        public ConsoleLogWriter(ILogger logger = null) : base(logger)
        {

        }

        public override void WriteError(string message)
        {
            Console.WriteLine(message);
            base.WriteError(message);
        }
    }
}
