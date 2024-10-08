using Configurations;
using Microsoft.Extensions.Logging;

namespace Microsoft.Logs;

public sealed class FixedMessageMicrosoftEmptyLogger
{
    private readonly Logger<FixedMessageMicrosoftEmptyLogger> _logger;

    public FixedMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<FixedMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation() => _logger.LogInformation("Just a plain fixed Message");


    public static void IterateExecution100MillionTimes_Information()
    {
        var fixedMessageMicrosoftEmptyLogger = new FixedMessageMicrosoftEmptyLogger(LogLevel.Information);

        for (int i = 0; i < Constants.Iterations; i++)
            fixedMessageMicrosoftEmptyLogger.ExecuteInformation();
    }

    public static void IterateExecution100MillionTimes_Warning()
    {
        var fixedMessageMicrosoftEmptyLogger = new FixedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            fixedMessageMicrosoftEmptyLogger.ExecuteInformation();
    }
}
