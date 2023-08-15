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
}
