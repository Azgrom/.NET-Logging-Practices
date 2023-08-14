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
}
