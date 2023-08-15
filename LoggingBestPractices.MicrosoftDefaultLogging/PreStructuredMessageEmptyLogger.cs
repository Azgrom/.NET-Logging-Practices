using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreStructuredMessageMicrosoftEmptyLogger
{
    private readonly Logger<PreStructuredMessageMicrosoftEmptyLogger> _logger;

    public PreStructuredMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<PreStructuredMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder.SetMinimumLevel(logLevel))
        );

    public void Execute() =>
        _logger.LogInformation("Random number {NextRandomInteger}", Random.Shared.Next());
}
