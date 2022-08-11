using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));

var logger = new Logger<Program>(loggerFactory);

for (int i = 0; i < 100_000_000; i++)
{
    // logger.LogInformation("Random number {RandomNumber}", Random.Shared.Next());
    logger.LogInformation($"Random number {Random.Shared.Next()}");
}
