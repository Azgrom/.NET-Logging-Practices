using Configurations;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreInterpolatedMessageMicrosoftEmptyLogger
{
    private readonly Logger<PreInterpolatedMessageMicrosoftEmptyLogger> _logger;

    public PreInterpolatedMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<PreInterpolatedMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void Execute(Func<int> nextRandomNumberGenerator) => _logger.LogInformation($"Random number {nextRandomNumberGenerator}");

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new PreInterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.Execute(nextRandomNumberGenerator);
    }
}
