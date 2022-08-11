using System;
using Serilog;

var logger = new LoggerConfiguration().MinimumLevel.Warning().WriteTo.Console().CreateLogger();

for (int i = 0; i < 100_000_000; i++)
{
    logger.Information("Random number {RandomNumber}", Random.Shared.Next());
    // logger.Information($"Random number {Random.Shared.Next()}");
}
