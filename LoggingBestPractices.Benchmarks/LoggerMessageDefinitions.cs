using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks
{
    public static class LoggerMessageDefinitions
    {
        private static readonly Action<ILogger, int, int, Exception?> LogMessageDefinition =
            LoggerMessage.Define<int, int>(LogLevel.Information, new EventId(0, string.Empty),
                "Log with parameters {0} and {1}");

        public static void LogBenchmarkMessage(this ILogger logger, int first, int second) =>
            LogMessageDefinition(logger, first, second, null);
    }
}
