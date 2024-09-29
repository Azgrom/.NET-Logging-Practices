using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class StructuredMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public StructuredMessageSerilogConsoleLogger(LogLevel logLevel) =>
        _logger = logLevel switch
        {
            LogLevel.Warning => new LoggerConfiguration()
                .CreateLogger(),
            LogLevel.Information => new LoggerConfiguration()
                .CreateLogger(),
            _ => _logger = new LoggerConfiguration()
                .CreateLogger()
        };

    public void Execute(Func<int> nextRandomNumberGenerator) =>
        _logger.Information("Random number {NextRandomInteger}", nextRandomNumberGenerator);

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageSerilogConsoleLogger = new StructuredMessageSerilogConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
        {
            preStructuredMessageSerilogConsoleLogger.Execute(nextRandomNumberGenerator);
        }
    }
}
