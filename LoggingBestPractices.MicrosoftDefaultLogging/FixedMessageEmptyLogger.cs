using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class FixedMessageMicrosoftEmptyLogger
{
    private readonly Logger<FixedMessageMicrosoftEmptyLogger> _logger;

    public FixedMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<FixedMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder.SetMinimumLevel(logLevel))
        );

    public void Execute() => _logger.LogInformation("Just a plain fixed Message");

    public static void IterateExecution100MillionTimes_Warning()
    {
        var fixedMessageMicrosoftEmptyLogger = new FixedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < 100_000_000; i++)
            fixedMessageMicrosoftEmptyLogger.Execute();
    }
}
