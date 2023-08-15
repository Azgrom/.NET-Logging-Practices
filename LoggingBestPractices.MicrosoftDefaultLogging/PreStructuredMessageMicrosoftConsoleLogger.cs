using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreStructuredMessageMicrosoftConsoleLogger
{
    private readonly Logger<PreStructuredMessageMicrosoftConsoleLogger> _logger;

    public PreStructuredMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
        _logger = new Logger<PreStructuredMessageMicrosoftConsoleLogger>(
            LoggerFactory.Create(builder => builder.AddConsole()
                .SetMinimumLevel(logLevel))
        );

    public void Execute() =>
        _logger.LogInformation("Random number {NextRandomInteger}", Random.Shared.Next());

    public static void IterateExecution100MillionTimes_Warning()
    {
        var preStructuredMessageMicrosoftConsoleLogger = new PreStructuredMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            preStructuredMessageMicrosoftConsoleLogger.Execute();
    }
}
