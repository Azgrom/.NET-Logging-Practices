using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class InterpolatedMessageSerilogEmptyLogger
{
    private readonly ILogger _logger;

    public InterpolatedMessageSerilogEmptyLogger(LogLevel logLevel) =>
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

    public void Execute(Func<int> nextRandomNumberGenerator) =>
        _logger.Information($"Random number {nextRandomNumberGenerator}");

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageSerilogEmptyLogger = new InterpolatedMessageSerilogEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preInterpolatedMessageSerilogEmptyLogger.Execute(nextRandomNumberGenerator);
    }
}
