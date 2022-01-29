using System;

namespace IJ_Rasp03_Logging
{
    internal class FridayLogWritter : ILogger
    {
        private readonly ILogger _logger;

        public FridayLogWritter(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void WriteError(string message)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
            {
                _logger.WriteError(message);
            }
        }
    }
}
