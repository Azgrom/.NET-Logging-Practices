using Configurations;
using Microsoft.Extensions.Logging;
using Serilog.Events;

namespace Serilog.Logs;

public class FixedMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public FixedMessageSerilogConsoleLogger(LogLevel logLevel) =>
        _logger = logLevel switch
        {
            LogLevel.Warning => new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Warning)
                .CreateLogger(),
            LogLevel.Information => new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Information)
                .CreateLogger(),
            _ => _logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger()
        };

    public void ExecuteInformation() =>
        _logger.Information("Just a plain fixed Message");

    public static void IterateExecutionNMillionTimes_Warning()
    {
        var fixedMessageSerilogConsoleLogger = new FixedMessageSerilogConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            fixedMessageSerilogConsoleLogger.ExecuteInformation();
    }
}
