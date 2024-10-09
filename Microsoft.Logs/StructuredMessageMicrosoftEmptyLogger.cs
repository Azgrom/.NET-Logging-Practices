using Configurations;
using Microsoft.Extensions.Logging;

namespace Microsoft.Logs;

public sealed class StructuredMessageMicrosoftEmptyLogger
{
    private readonly Logger<StructuredMessageMicrosoftEmptyLogger> _logger;

    public StructuredMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<StructuredMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.LogInformation("Random number {NextRandomInteger}", nextRandomNumberGenerator());

    public static void ExecuteNMillionTimes_Information()
    {
        var random = new Random();
        IterateExecutionNMillionTimes_Information(random.Next);
    }

    public static void ExecuteNMillionTimes_Warning()
    {
        var random = new Random();
        IterateExecutionNMillionTimes_Warning(random.Next);
    }

    public static void IterateExecutionNMillionTimes_Information(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftEmptyLogger = new StructuredMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftEmptyLogger = new StructuredMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
