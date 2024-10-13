using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging
{
    public class FixedMessageSerilogConsoleLogger
    {
        private readonly ILogger _logger;

        public FixedMessageSerilogConsoleLogger(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Warning:
                    _logger = new LoggerConfiguration().WriteTo.Console(LogEventLevel.Warning).CreateLogger();
                    break;
                case LogLevel.Information:
                    _logger = new LoggerConfiguration().WriteTo.Console(LogEventLevel.Information).CreateLogger();
                    break;
                default:
                    _logger = _logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
                    break;
            }
        }

        public void Execute() =>
            _logger.Information("Just a plain fixed Message");
    }
}
