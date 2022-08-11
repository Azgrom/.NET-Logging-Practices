using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private const string LogWithParameters = "Log with parameters {0} and {1}";
    private const string LogWithoutParameters = "Log without parameters";

    private readonly ILoggerFactory _loggerFactory =
        LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));

    private readonly ILogger<Benchmarks> _logger;

    public Benchmarks() => _logger = new Logger<Benchmarks>(_loggerFactory);

    [Benchmark]
    public void Log_WithoutIf_WithoutParams() => _logger.LogInformation(LogWithoutParameters);

    [Benchmark]
    public void Log_WithIf_WithoutParams()
    {
        if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation(LogWithoutParameters);
    }

    [Benchmark]
    public void Log_WithoutIf_WithParams() => _logger.LogInformation(LogWithParameters, 51, 64);

    [Benchmark]
    public void Log_WithIf_WithParams()
    {
        if (_logger.IsEnabled(LogLevel.Information)) _logger.LogInformation(LogWithParameters, 51, 64);
    }
}
