using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging
{
    public sealed class FixedMessageMicrosoftConsoleLogger
    {
        private readonly Logger<FixedMessageMicrosoftConsoleLogger> _logger;

        public FixedMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
            _logger = new Logger<FixedMessageMicrosoftConsoleLogger>(
                LoggerFactory.Create(builder => builder.AddConsole()
                    .SetMinimumLevel(logLevel))
            );

        public void Execute() => _logger.LogInformation("Just a plain fixed Message");
    }
}
