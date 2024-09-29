using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.DefaultLogging;

internal class Program
{
    public static void Main(string[] args)
    {
        const LogLevel logLevel = LogLevel.Warning;

        var random = new Random();
        var preInterpolatedMessageLogger = new PreInterpolatedMessageMicrosoftConsoleLogger(logLevel);

        for (var i = 0; i < 100_000_000; i++)
            preInterpolatedMessageLogger.Execute(random.Next);
    }
}
// logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
// logger.LogInformation($"Random number {Random.Shared.Next()}");
