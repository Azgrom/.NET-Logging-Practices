using Configurations;
using Microsoft.Extensions.Logging;

namespace Microsoft.Logs;

internal class Program
{
    public static void Main(string[] args)
    {
        const LogLevel logLevel = LogLevel.Warning;

        var random = new Random();
        var preInterpolatedMessageLogger = new InterpolatedMessageMicrosoftConsoleLogger(logLevel);

        for (var i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageLogger.ExecuteInformation(random.Next);
    }
}
// logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
// logger.LogInformation($"Random number {Random.Shared.Next()}");
