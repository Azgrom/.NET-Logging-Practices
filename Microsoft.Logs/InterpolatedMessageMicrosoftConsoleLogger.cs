using Configurations;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace Microsoft.Logs;

public sealed class InterpolatedMessageMicrosoftConsoleLogger
{
    private readonly Logger<InterpolatedMessageMicrosoftConsoleLogger> _logger;

    public InterpolatedMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
        _logger = new Logger<InterpolatedMessageMicrosoftConsoleLogger>(
            LoggerFactory.Create(builder => builder.AddConsole()
                .SetMinimumLevel(logLevel))
        );

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) => _logger.LogInformation($"Random number {nextRandomNumberGenerator()}");

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftConsoleLogger = new InterpolatedMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftConsoleLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
