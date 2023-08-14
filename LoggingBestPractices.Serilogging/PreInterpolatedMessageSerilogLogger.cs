using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class PreInterpolatedMessageSerilogLogger
{
    private readonly ILogger _logger;

    public PreInterpolatedMessageSerilogLogger(LogLevel logLevel) =>
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
        _logger.Information($"Random number {Random.Shared.Next()}");
}
