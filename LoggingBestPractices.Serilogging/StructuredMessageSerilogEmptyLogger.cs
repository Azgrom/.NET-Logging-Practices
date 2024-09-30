using Configurations;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

public class StructuredMessageSerilogEmptyLogger
{
    private readonly ILogger _logger;

    public StructuredMessageSerilogEmptyLogger(LogLevel logLevel) =>
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
        _logger.Information("Random number {NextRandomInteger}", nextRandomNumberGenerator());

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageSerilogEmptyLogger = new StructuredMessageSerilogEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preStructuredMessageSerilogEmptyLogger.Execute(nextRandomNumberGenerator);
    }
}
