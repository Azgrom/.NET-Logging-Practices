using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging
{
    public sealed class FixedMessageMicrosoftLogger
    {
        private readonly Logger<FixedMessageMicrosoftLogger> _logger;

        public FixedMessageMicrosoftLogger(LogLevel logLevel) =>
            _logger = new Logger<FixedMessageMicrosoftLogger>(
                LoggerFactory.Create(builder => builder.SetMinimumLevel(logLevel))
            );

        public void Execute() => _logger.LogInformation("Just a plain fixed Message");
    }
}
