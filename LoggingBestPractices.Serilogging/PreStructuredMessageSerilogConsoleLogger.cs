using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class PreStructuredMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public PreStructuredMessageSerilogConsoleLogger(LogLevel logLevel) =>
        _logger = logLevel switch
        {
            LogLevel.Warning => new LoggerConfiguration()
                .CreateLogger(),
            LogLevel.Information => new LoggerConfiguration()
                .CreateLogger(),
            _ => _logger = new LoggerConfiguration()
                .CreateLogger()
        };

    public void Execute() =>
        _logger.Information("Random number {NextRandomInteger}", Random.Shared.Next());
}
