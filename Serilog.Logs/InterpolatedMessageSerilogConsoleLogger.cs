using Configurations;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;
// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace Serilog.Logs;

public class InterpolatedMessageSerilogConsoleLogger
{
    private readonly ILogger _logger;

    public InterpolatedMessageSerilogConsoleLogger(LogLevel logLevel) =>
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

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.Information($"Random number {nextRandomNumberGenerator()}");

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageSerilogConsoleLogger = new InterpolatedMessageSerilogConsoleLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageSerilogConsoleLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
