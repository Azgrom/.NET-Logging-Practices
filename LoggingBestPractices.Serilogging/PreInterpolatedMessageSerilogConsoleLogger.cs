using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class PreInterpolatedMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public PreInterpolatedMessageSerilogConsoleLogger(LogLevel logLevel) =>
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
        _logger.Information($"Random number {Random.Shared.Next()}");

    public static void IterateExecution100MillionTimes_Warning()
    {
        var preInterpolatedMessageSerilogConsoleLogger = new PreInterpolatedMessageSerilogConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preInterpolatedMessageSerilogConsoleLogger.Execute();
    }
}
