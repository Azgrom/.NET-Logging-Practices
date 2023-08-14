using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreInterpolatedMessageMicrosoftLogger
{
    private readonly Logger<PreInterpolatedMessageMicrosoftLogger> _logger;

    public PreInterpolatedMessageMicrosoftLogger(LogLevel logLevel) =>
        _logger = new Logger<PreInterpolatedMessageMicrosoftLogger>(
            LoggerFactory.Create(builder => builder.SetMinimumLevel(logLevel))
        );

    public void Execute() => _logger.LogInformation($"Random number {Random.Shared.Next()}");
}
