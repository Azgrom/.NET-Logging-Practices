using Configurations;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Serilogging;

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

    public void Execute() =>
        _logger.Information("Just a plain fixed Message");

    public static void IterateExecution100MillionTimes_Warning()
    {
        var fixedMessageSerilogEmptyLogger = new FixedMessageSerilogEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            fixedMessageSerilogEmptyLogger.Execute();
    }
}
