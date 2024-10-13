using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging
{
    public sealed class PreInterpolatedMessageMicrosoftConsoleLogger
    {
        private readonly Logger<PreInterpolatedMessageMicrosoftConsoleLogger> _logger;

        public PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
            _logger = new Logger<PreInterpolatedMessageMicrosoftConsoleLogger>(
                LoggerFactory.Create(builder => builder.AddConsole()
                    .SetMinimumLevel(logLevel))
            );

        public void Execute() => _logger.LogInformation($"Random number {new Random().Next()}");
    }
}
