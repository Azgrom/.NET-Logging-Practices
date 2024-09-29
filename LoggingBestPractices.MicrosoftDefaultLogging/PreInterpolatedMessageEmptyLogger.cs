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

    public void Execute() => _logger.LogInformation($"Random number {Random.Shared.Next()}");

    public static void IterateExecution100MillionTimes_Warning()
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new PreInterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.Execute();
    }
}
