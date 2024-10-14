using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace LoggingBestPractices.Benchmarks;

[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[ThreadingDiagnoser]
[RPlotExporter]
public class CompareEmptyLogsBenchmark
{
    private const string LogMessageWithParameters =
        "This is a log message with parameters {0}, {1} and {2}";

    private const    string                             ConstantLogMessageTemplate = "Fixed Log Message";
    private readonly ILogger<CompareEmptyLogsBenchmark> _defaultLogger;
    private readonly LoggerConfiguration                _loggerConfiguration = new();

    private readonly ILoggerFactory _loggerFactory
        = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));

    private readonly ILogger _serilogLogger;

    public CompareEmptyLogsBenchmark()
    {
        _defaultLogger = new Logger<CompareEmptyLogsBenchmark>(_loggerFactory);
        _serilogLogger = _loggerConfiguration.MinimumLevel.Warning().CreateLogger();
    }

    [Benchmark]
    public void ConstantTemplate_DefaultLogger_Without_If()
    {
        _defaultLogger.LogInformation(ConstantLogMessageTemplate);
    }

    [Benchmark]
    public void ConstantTemplate_DefaultLogger_With_If()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information)) _defaultLogger.LogInformation(ConstantLogMessageTemplate);
    }

    [Benchmark]
    public void Parameterized_DefaultLogger_Without_If_WithParams()
    {
        _defaultLogger.LogInformation(LogMessageWithParameters, 50, 75, 125);
    }

    [Benchmark]
    public void Parameterized_DefaultLogger_With_If_WithParams()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information))
            _defaultLogger.LogInformation(LogMessageWithParameters, 40, 70, 175);
    }

    [Benchmark]
    public void Formatted_DefaultLogger_Without_If_WithParams()
    {
        _defaultLogger.LogInformation(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    public void Formatted_DefaultLogger_With_If_WithParams()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information))
            _defaultLogger.LogInformation(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    public void Interpolated_DefaultLogger_Without_If_WithParams()
    {
        _defaultLogger.LogInformation($"This is a log message with parameters {464}, {4542}, {0}");
    }

    [Benchmark]
    public void Interpolated_DefaultLogger_With_If_WithParams()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information))
            _defaultLogger.LogInformation($"This is a log message with parameters {464}, {4542}, {0}");
    }

    [Benchmark]
    public void ConstantTemplate_SerilogLogger_Without_If() { _serilogLogger.Information(ConstantLogMessageTemplate); }

    [Benchmark]
    public void ConstantTemplate_SerilogLogger_With_If()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information)) _serilogLogger.Information(ConstantLogMessageTemplate);
    }

    [Benchmark]
    public void Parameterized_SerilogLogger_Without_If_WithParams()
    {
        _serilogLogger.Information(LogMessageWithParameters, 50, 75, 125);
    }

    [Benchmark]
    public void Parameterized_SerilogLogger_With_If_WithParams()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information))
            _serilogLogger.Information(LogMessageWithParameters, 40, 70, 175);
    }

    [Benchmark]
    public void Formatted_SerilogLogger_Without_If_WithParams()
    {
        _serilogLogger.Information(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    public void Formatted_SerilogLogger_With_If_WithParams()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information))
            _serilogLogger.Information(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    public void Interpolated_SerilogLogger_Without_If_WithParams()
    {
        _serilogLogger.Information($"This is a log message with parameters {464}, {4542}, {0}");
    }

    [Benchmark]
    public void Interpolated_SerilogLogger_With_If_WithParams()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information))
            _serilogLogger.Information($"This is a log message with parameters {464}, {4542}, {0}");
    }
}
