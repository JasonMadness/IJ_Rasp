using System.IO;

namespace IJ_Rasp03_Logging
{
    internal class FileLogWritter : ILogger
    {
        private readonly ILogger _logger;

        public FileLogWritter(ILogger logger = null)
        {
            _logger = logger;
        }

        public void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
            _logger?.WriteError(message);
        }
    }
}
