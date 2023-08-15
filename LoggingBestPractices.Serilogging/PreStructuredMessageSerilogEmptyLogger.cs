using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class PreStructuredMessageSerilogEmptyLogger
{
    private readonly ILogger _logger;

    public PreStructuredMessageSerilogEmptyLogger(LogLevel logLevel) =>
        _logger = logLevel switch
        {
            LogLevel.Warning => new LoggerConfiguration()
                .MinimumLevel.Warning()
                .CreateLogger(),
            LogLevel.Information => new LoggerConfiguration()
                .MinimumLevel.Information()
                .CreateLogger(),
            _ => _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .CreateLogger()
        };

    public void Execute() =>
        _logger.Information("Random number {NextRandomInteger}", Random.Shared.Next());
}
