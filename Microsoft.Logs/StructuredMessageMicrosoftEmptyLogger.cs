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

    public static void Execute100MillionTimes_Information()
    {
        var random = new Random();
        IterateExecution100MillionTimes_Information(random.Next);
    }

    public static void Execute100MillionTimes_Warning()
    {
        var random = new Random();
        IterateExecution100MillionTimes_Warning(random.Next);
    }

    public static void IterateExecution100MillionTimes_Information(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftEmptyLogger = new StructuredMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preStructuredMessageMicrosoftEmptyLogger = new StructuredMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preStructuredMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
