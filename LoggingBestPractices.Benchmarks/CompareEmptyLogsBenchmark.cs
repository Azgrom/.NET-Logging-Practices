using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace LoggingBestPractices.Benchmarks;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[RPlotExporter]
public class CompareEmptyLogsBenchmark
{
    private const string ConstantLogMessageCategory = "Compile-Time Constant Log Template Category";
    private const string FormattedLogMessageCategory = "Formatted Log Template Category";
    private const string InterpolatedLogMessageCategory = "Interpolated Log Template Category";
    private const string ParameterizedLogMessageCategory = "Parameterized Log Template Category";
    private const string LogMessageWithParameters =
        "This is a log message with parameters {0}, {1} and {2}";

    private const    string                             ConstantLogMessageTemplate = "Fixed Log Message";
    private readonly ILogger<CompareEmptyLogsBenchmark> _defaultLogger;
    private readonly LoggerConfiguration                _loggerConfiguration = new();

    private readonly ILoggerFactory _loggerFactory
        = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));

    private readonly Logger _serilogLogger;

    public CompareEmptyLogsBenchmark()
    {
        _defaultLogger = new Logger<CompareEmptyLogsBenchmark>(_loggerFactory);
        _serilogLogger = _loggerConfiguration.MinimumLevel.Warning().CreateLogger();
    }

    [Benchmark]
    [BenchmarkCategory(ConstantLogMessageCategory)]
    public void ConstantTemplate_DefaultLogger_Without_If()
    {
        _defaultLogger.LogInformation(ConstantLogMessageTemplate);
    }

    [Benchmark]
    [BenchmarkCategory(ConstantLogMessageCategory)]
    public void ConstantTemplate_DefaultLogger_With_If()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information)) _defaultLogger.LogInformation(ConstantLogMessageTemplate);
    }

    [Benchmark]
    [BenchmarkCategory(ParameterizedLogMessageCategory)]
    public void Parameterized_DefaultLogger_Without_If_WithParams()
    {
        _defaultLogger.LogInformation(LogMessageWithParameters, 50, 75, 125);
    }

    [Benchmark]
    [BenchmarkCategory(ParameterizedLogMessageCategory)]
    public void Parameterized_DefaultLogger_With_If_WithParams()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information))
            _defaultLogger.LogInformation(LogMessageWithParameters, 40, 70, 175);
    }

    [Benchmark]
    [BenchmarkCategory(FormattedLogMessageCategory)]
    public void Formatted_DefaultLogger_Without_If_WithParams()
    {
        _defaultLogger.LogInformation(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    [BenchmarkCategory(FormattedLogMessageCategory)]
    public void Formatted_DefaultLogger_With_If_WithParams()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information))
            _defaultLogger.LogInformation(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    [BenchmarkCategory(InterpolatedLogMessageCategory)]
    public void Interpolated_DefaultLogger_Without_If_WithParams()
    {
        _defaultLogger.LogInformation($"This is a log message with parameters {464}, {4542}, {0}");
    }

    [Benchmark]
    [BenchmarkCategory(InterpolatedLogMessageCategory)]
    public void Interpolated_DefaultLogger_With_If_WithParams()
    {
        if (_defaultLogger.IsEnabled(LogLevel.Information))
            _defaultLogger.LogInformation($"This is a log message with parameters {464}, {4542}, {0}");
    }

    [Benchmark]
    [BenchmarkCategory(ConstantLogMessageCategory)]
    public void ConstantTemplate_SerilogLogger_Without_If() { _serilogLogger.Information(ConstantLogMessageTemplate); }

    [Benchmark]
    [BenchmarkCategory(ConstantLogMessageCategory)]
    public void ConstantTemplate_SerilogLogger_With_If()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information)) _serilogLogger.Information(ConstantLogMessageTemplate);
    }

    [Benchmark]
    [BenchmarkCategory(ParameterizedLogMessageCategory)]
    public void Parameterized_SerilogLogger_Without_If_WithParams()
    {
        _serilogLogger.Information(LogMessageWithParameters, 50, 75, 125);
    }

    [Benchmark]
    [BenchmarkCategory(ParameterizedLogMessageCategory)]
    public void Parameterized_SerilogLogger_With_If_WithParams()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information))
            _serilogLogger.Information(LogMessageWithParameters, 40, 70, 175);
    }

    [Benchmark]
    [BenchmarkCategory(FormattedLogMessageCategory)]
    public void Formatted_SerilogLogger_Without_If_WithParams()
    {
        _serilogLogger.Information(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    [BenchmarkCategory(FormattedLogMessageCategory)]
    public void Formatted_SerilogLogger_With_If_WithParams()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information))
            _serilogLogger.Information(string.Format(LogMessageWithParameters, 5, 7, 2));
    }

    [Benchmark]
    [BenchmarkCategory(InterpolatedLogMessageCategory)]
    public void Interpolated_SerilogLogger_Without_If_WithParams()
    {
        _serilogLogger.Information($"This is a log message with parameters {464}, {4542}, {0}");
    }

    [Benchmark]
    [BenchmarkCategory(InterpolatedLogMessageCategory)]
    public void Interpolated_SerilogLogger_With_If_WithParams()
    {
        if (_serilogLogger.IsEnabled(LogEventLevel.Information))
            _serilogLogger.Information($"This is a log message with parameters {464}, {4542}, {0}");
    }
}
