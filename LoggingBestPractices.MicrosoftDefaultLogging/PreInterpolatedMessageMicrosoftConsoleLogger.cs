using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreInterpolatedMessageMicrosoftConsoleLogger
{
    private readonly Logger<PreInterpolatedMessageMicrosoftConsoleLogger> _logger;

    public PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
        _logger = new Logger<PreInterpolatedMessageMicrosoftConsoleLogger>(
            LoggerFactory.Create(builder => builder.AddConsole()
                .SetMinimumLevel(logLevel))
        );

    public void Execute() => _logger.LogInformation($"Random number {Random.Shared.Next()}");

    public static void IterateExecution100MillionTimes_Warning()
    {
        var preInterpolatedMessageMicrosoftConsoleLogger = new PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preInterpolatedMessageMicrosoftConsoleLogger.Execute();
    }
}
