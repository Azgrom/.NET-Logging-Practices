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


    public static void ExecuteNTimes_Information()
    {
        var random = new Random();
        IterateExecutionNMillionTimes_Information(random.Next);
    }

    public static void ExecuteNTimes_Warning()
    {
        var random = new Random();
        IterateExecutionNMillionTimes_Warning(random.Next);
    }

    public static void IterateExecutionNMillionTimes_Information(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftConsoleLogger
            = new StructuredMessageMicrosoftConsoleLogger(LogLevel.Information);

        for (var i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftConsoleLogger.ExecuteInformation(nextRandomNumberGenerator);
    }

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftConsoleLogger = new StructuredMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftConsoleLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
