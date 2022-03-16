using System;
using System.IO;

namespace Rasp_Logger
{
    internal class FileLogWriter : LogWriter
    {
        public FileLogWriter(ILogger logger = null) : base(logger)
        {

        }

        public override void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
            base.WriteError(message);
        }
    }
}
