using System;

namespace Rasp_Logger
{
    internal class Pathfinder
    {
        private readonly ILogger _logger;

        public Pathfinder(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Find(string message)
        {
            _logger.WriteError(message);
        }
    }
}
