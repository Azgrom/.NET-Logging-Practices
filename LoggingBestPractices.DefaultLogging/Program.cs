using System;
using LoggingBestPractices.Benchmarks;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));

var logger = new Logger<Program>(loggerFactory);
var adaptedLogger = new LoggerAdapter<Program>(logger);

for (int i = 0; i < 100_000_000; i++)
{
    logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
    // logger.LogInformation($"Random number {Random.Shared.Next()}");
    // adaptedLogger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
}
