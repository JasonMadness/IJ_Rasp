using System;

namespace IJ_Rasp03_Logging
{
    internal class ConsoleLogWritter : ILogger
    {
        private readonly ILogger _logger;

        public ConsoleLogWritter(ILogger logger = null)
        {
            _logger = logger;
        }

        public void WriteError(string message)
        {
            Console.WriteLine(message);
            _logger?.WriteError(message);
        }
    }
}
