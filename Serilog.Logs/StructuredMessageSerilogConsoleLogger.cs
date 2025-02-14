using Configurations;
using Microsoft.Extensions.Logging;

namespace Serilog.Logs;

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

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.Information("Random number {NextRandomInteger}", nextRandomNumberGenerator());

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageSerilogConsoleLogger = new StructuredMessageSerilogConsoleLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++)
            preStructuredMessageSerilogConsoleLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
