using Configurations;
using Microsoft.Extensions.Logging;

// ReSharper disable TemplateIsNotCompileTimeConstantProblem

namespace Serilog.Logs;

public class InterpolatedMessageSerilogEmptyLogger
{
    private readonly ILogger _logger;

    public InterpolatedMessageSerilogEmptyLogger(LogLevel logLevel) =>
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

    public void ExecuteInformation(Func<int> nextRandomNumberGenerator) =>
        _logger.Information($"Random number {nextRandomNumberGenerator()}");

    public static void IterateExecutionNMillionTimes_Warning(Func<int> nextRandomNumberGenerator)
    {
        var preInterpolatedMessageSerilogEmptyLogger = new InterpolatedMessageSerilogEmptyLogger(LogLevel.Warning);

        for (int i = 0; i < Constants.Iterations; i++)
            preInterpolatedMessageSerilogEmptyLogger.ExecuteInformation(nextRandomNumberGenerator);
    }
}
