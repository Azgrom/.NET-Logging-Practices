using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging
{
    public class PreStructuredMessageSerilogLogger
    {
        private readonly ILogger _logger;

        public PreStructuredMessageSerilogLogger(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Warning:
                case LogLevel.Information:
                    _logger = new LoggerConfiguration().CreateLogger();
                    break;
                default:
                    _logger = _logger = new LoggerConfiguration().CreateLogger();
                    break;
            }
        }

        public void Execute() =>
            _logger.Information("Random number {NextRandomInteger}", new Random().Next());
    }
}
