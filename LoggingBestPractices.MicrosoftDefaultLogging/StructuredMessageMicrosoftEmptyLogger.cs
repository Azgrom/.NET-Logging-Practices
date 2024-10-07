using Configurations;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class StructuredMessageMicrosoftEmptyLogger
{
    private readonly Logger<StructuredMessageMicrosoftEmptyLogger> _logger;

    public StructuredMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<StructuredMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.LogInformation("Random number {NextRandomInteger}", nextRandomNumberGenerator());

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftEmptyLogger = new StructuredMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
