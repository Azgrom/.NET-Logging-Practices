using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging
{
    public class FixedMessageSerilogLogger
    {
        private readonly ILogger _logger;

        public FixedMessageSerilogLogger(LogLevel logLevel)
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
            _logger.Information("Just a plain fixed Message");
    }
}
