using Configurations;
using Microsoft.Extensions.Logging;

namespace Microsoft.Logs;

public sealed class FixedMessageMicrosoftConsoleLogger
{
    private readonly Logger<FixedMessageMicrosoftConsoleLogger> _logger;

    public FixedMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
        _logger = new Logger<FixedMessageMicrosoftConsoleLogger>(
            LoggerFactory.Create(builder => builder.AddConsole()
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation() => _logger.LogInformation("Just a plain fixed Message");

    public static void IterateExecutionNMillionTimes_Information()
    {
        var fixedMessageMicrosoftConsoleLogger = new FixedMessageMicrosoftConsoleLogger(LogLevel.Information);

        for (int i = 0; i < Constants.Iterations; i++)
            fixedMessageMicrosoftConsoleLogger.ExecuteInformation();
    }

    public static void IterateExecutionNMillionTimes_Warning()
    {
        var fixedMessageMicrosoftConsoleLogger = new FixedMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            fixedMessageMicrosoftConsoleLogger.ExecuteInformation();
    }
}
