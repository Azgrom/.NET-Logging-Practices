using Configurations;
using Microsoft.Extensions.Logging;

namespace Microsoft.Logs;

public sealed class StructuredMessageMicrosoftConsoleLogger
{
    private readonly Logger<StructuredMessageMicrosoftConsoleLogger> _logger;

    public StructuredMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
        _logger = new Logger<StructuredMessageMicrosoftConsoleLogger>(
            LoggerFactory.Create(builder => builder.AddConsole()
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.LogInformation("Random number {NextRandomInteger}", nextRandomNumberGenerator());

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftConsoleLogger = new StructuredMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftConsoleLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
