using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreStructuredMessageMicrosoftLogger
{
    private readonly Logger<PreStructuredMessageMicrosoftLogger> _logger;

    public PreStructuredMessageMicrosoftLogger(LogLevel logLevel) =>
        _logger = new Logger<PreStructuredMessageMicrosoftLogger>(
            LoggerFactory.Create(builder => builder.SetMinimumLevel(logLevel))
        );

    public void Execute() =>
        _logger.LogInformation("Random number {NextRandomInteger}", Random.Shared.Next());
}
