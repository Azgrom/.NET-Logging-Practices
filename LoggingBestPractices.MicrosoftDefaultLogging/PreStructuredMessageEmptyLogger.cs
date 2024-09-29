using Configurations;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreStructuredMessageMicrosoftEmptyLogger
{
    private readonly Logger<PreStructuredMessageMicrosoftEmptyLogger> _logger;

    public PreStructuredMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<PreStructuredMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void Execute(Func<int> nextRandomNumberGenerator) =>
        _logger.LogInformation("Random number {NextRandomInteger}", nextRandomNumberGenerator());

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftEmptyLogger = new PreStructuredMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftEmptyLogger.Execute(nextRandomNumberGenerator);
    }
}
