using Configurations;
using Microsoft.Extensions.Logging;
// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace LoggingBestPractices.DefaultLogging;

public sealed class InterpolatedMessageMicrosoftEmptyLogger
{
    private readonly Logger<InterpolatedMessageMicrosoftEmptyLogger> _logger;

    public InterpolatedMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<InterpolatedMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) => _logger.LogInformation($"Random number {nextRandomNumberGenerator()}");

    public static void Execute100MillionTimes_Information()
    {
        var random = new Random();
        IterateExecution100MillionTimes_Information(random.Next);
    }

    public static void Execute100MillionTimes_Warning()
    {
        var random = new Random();
        IterateExecution100MillionTimes_Information(random.Next);
    }

    public static void IterateExecution100MillionTimes_Information(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
