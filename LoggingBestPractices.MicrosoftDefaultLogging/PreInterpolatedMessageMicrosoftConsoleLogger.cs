using Configurations;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

public sealed class PreInterpolatedMessageMicrosoftConsoleLogger
{
    private readonly Logger<PreInterpolatedMessageMicrosoftConsoleLogger> _logger;

    public PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel logLevel) =>
        _logger = new Logger<PreInterpolatedMessageMicrosoftConsoleLogger>(
            LoggerFactory.Create(builder => builder.AddConsole()
                .SetMinimumLevel(logLevel))
        );

    public void Execute(Func<int> nextRandomNumberGenerator) => _logger.LogInformation($"Random number {nextRandomNumberGenerator}");

    public static void IterateExecution100MillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageMicrosoftConsoleLogger = new PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageMicrosoftConsoleLogger.Execute(nextRandomNumberGenerator);
    }
}
