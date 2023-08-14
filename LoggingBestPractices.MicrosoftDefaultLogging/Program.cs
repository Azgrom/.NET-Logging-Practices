using LoggingBestPractices.DefaultLogging;
using Microsoft.Extensions.Logging;

const LogLevel logLevel = LogLevel.Warning;

var preInterpolatedMessageLogger = new PreInterpolatedMessageMicrosoftConsoleLogger(logLevel);

for (var i = 0; i < 100_000_000; i++)
    preInterpolatedMessageLogger.Execute();
// logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
// logger.LogInformation($"Random number {Random.Shared.Next()}");
