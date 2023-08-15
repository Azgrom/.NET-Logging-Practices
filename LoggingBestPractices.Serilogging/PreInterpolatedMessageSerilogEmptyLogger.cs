using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class PreInterpolatedMessageSerilogEmptyLogger
{
    private readonly ILogger _logger;

    public PreInterpolatedMessageSerilogEmptyLogger(LogLevel logLevel) =>
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
        _logger.Information($"Random number {Random.Shared.Next()}");

    public static void IterateExecution100MillionTimes_Warning()
    {
        var preInterpolatedMessageSerilogEmptyLogger = new PreInterpolatedMessageSerilogEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preInterpolatedMessageSerilogEmptyLogger.Execute();
    }
}
