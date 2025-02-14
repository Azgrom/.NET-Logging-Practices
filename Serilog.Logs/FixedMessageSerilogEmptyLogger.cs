using Configurations;
using Microsoft.Extensions.Logging;

namespace Serilog.Logs;

public class FixedMessageSerilogEmptyLogger
{
    private readonly ILogger _logger;

    public FixedMessageSerilogEmptyLogger(LogLevel logLevel) =>
        _logger = logLevel switch
        {
            LogLevel.Warning => new LoggerConfiguration()
                .MinimumLevel.Warning()
                .CreateLogger(),
            LogLevel.Information => new LoggerConfiguration()
                .MinimumLevel.Information()
                .CreateLogger(),
            _ => _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .CreateLogger()
        };

    public void ExecuteInformation() => _logger.Information("Just a plain fixed Message");

    public static void IterateExecutionNMillionTimes_Warning()
    {
        var fixedMessageSerilogEmptyLogger = new FixedMessageSerilogEmptyLogger(LogLevel.Warning);

        for (var i = 0; i < Constants.Iterations; i++) fixedMessageSerilogEmptyLogger.ExecuteInformation();
    }
}
