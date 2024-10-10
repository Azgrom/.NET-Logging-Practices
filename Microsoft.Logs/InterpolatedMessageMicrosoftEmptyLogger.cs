using Configurations;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace Microsoft.Logs;

public sealed class InterpolatedMessageMicrosoftEmptyLogger
{
    private readonly Logger<InterpolatedMessageMicrosoftEmptyLogger> _logger;

    public InterpolatedMessageMicrosoftEmptyLogger(LogLevel logLevel) =>
        _logger = new Logger<InterpolatedMessageMicrosoftEmptyLogger>(
            LoggerFactory.Create(builder => builder
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation(int nextRandomNumberGenerator) =>
        _logger.LogInformation("Random number {NextRandomInteger}", nextRandomNumberGenerator);

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.LogInformation($"Random number {nextRandomNumberGenerator()}");

    public static void ExecuteNMillionTimes_Information()
    {
        var random = new Random();
        IterateExecutionNMillionTimes_Information(random.Next);
    }

    public static void ExecuteNMillionTimes_Warning()
    {
        var random = new Random();
        IterateExecutionNMillionTimes_Information(random.Next);
    }

    public static void IterateExecutionNMillionTimes_Information(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
