using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class FixedMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public FixedMessageSerilogConsoleLogger(LogLevel logLevel) =>
        _logger = logLevel switch
        {
            LogLevel.Warning => new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Warning)
                .CreateLogger(),
            LogLevel.Information => new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Information)
                .CreateLogger(),
            _ => _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger()
        };

    public void Execute() =>
        _logger.Information("Just a plain fixed Message");
}
