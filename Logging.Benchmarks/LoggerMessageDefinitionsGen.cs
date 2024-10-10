using Microsoft.Extensions.Logging;

namespace Logging.Benchmarks;

public static partial class LoggerMessageDefinitionsGen
{
    [LoggerMessage(EventId = 0, Level = LogLevel.Information, Message = "Log with parameters {First} and {Second}")]
    public static partial void LogBenchmarkMessageGen(
        this ILogger logger,
        int          first,
        int          second
    );
}
