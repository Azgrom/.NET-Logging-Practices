using Serilog;

namespace LoggingBestPractices.Serilogging;

internal class Program
{
    public static void Main(string[] args)
    {
        var logger = new LoggerConfiguration().MinimumLevel.Warning()
            .WriteTo.Console()
            .CreateLogger();

        var random = new Random();
        for (var i = 0; i < 100_000_000; i++)
            logger.Information("Random number {RandomNumber}", random.Next());
    }
}
// logger.Information($"Random number {Random.Shared.Next()}");
