using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class InterpolatedMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public InterpolatedMessageSerilogConsoleLogger(LogLevel logLevel) =>
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

    public void Execute(Func<int> nextRandomNumberGenerator) =>
        _logger.Information($"Random number {nextRandomNumberGenerator}");

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageSerilogConsoleLogger = new InterpolatedMessageSerilogConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preInterpolatedMessageSerilogConsoleLogger.Execute(nextRandomNumberGenerator);
    }
}
