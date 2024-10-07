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

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftEmptyLogger = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
