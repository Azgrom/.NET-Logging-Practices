using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LoggingBestPractices.DefaultLogging;
using LoggingBestPractices.Serilogging;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[ThreadingDiagnoser]
public class Benchmarks
{
    private const string MicrosoftLoggerCategory = "Microsoft Logger";
    private const string SerilogLoggerCategory = "Serilog Logger";

    private FixedMessageMicrosoftLogger _fixedMessageMicrosoftLogger;
    private PreInterpolatedMessageMicrosoftLogger _preInterpolatedMessageMicrosoftLogger;
    private PreStructuredMessageMicrosoftLogger _preStructuredMessageMicrosoftLogger;

    private FixedMessageSerilogLogger _fixedMessageSerilogLogger;
    private PreInterpolatedMessageSerilogLogger _preInterpolatedMessageSerilogLogger;
    private PreStructuredMessageSerilogLogger _preStructuredMessageSerilogLogger;
    
    private FixedMessageMicrosoftConsoleLogger _fixedMessageMicrosoftConsoleLogger;
    private PreInterpolatedMessageMicrosoftConsoleLogger _preInterpolatedMessageMicrosoftConsoleLogger;
    private PreStructuredMessageMicrosoftConsoleLogger _preStructuredMessageMicrosoftConsoleLogger;

    private FixedMessageSerilogConsoleLogger _fixedMessageSerilogConsoleLogger;
    private PreInterpolatedMessageSerilogConsoleLogger _preInterpolatedMessageSerilogConsoleLogger;
    private PreStructuredMessageSerilogConsoleLogger _preStructuredMessageSerilogConsoleLogger;

    [Params(LogLevel.Information, LogLevel.Warning)]
    public LogLevel LogLevel;

    [GlobalSetup]
    public void Setup()
    {
        _fixedMessageMicrosoftLogger = new FixedMessageMicrosoftLogger(LogLevel);
        _preInterpolatedMessageMicrosoftLogger = new PreInterpolatedMessageMicrosoftLogger(LogLevel);
        _preStructuredMessageMicrosoftLogger = new PreStructuredMessageMicrosoftLogger(LogLevel);

        _fixedMessageSerilogLogger = new FixedMessageSerilogLogger(LogLevel);
        _preInterpolatedMessageSerilogLogger = new PreInterpolatedMessageSerilogLogger(LogLevel);
        _preStructuredMessageSerilogLogger = new PreStructuredMessageSerilogLogger(LogLevel);
        
        _fixedMessageMicrosoftConsoleLogger = new FixedMessageMicrosoftConsoleLogger(LogLevel);
        _preInterpolatedMessageMicrosoftConsoleLogger = new PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel);
        _preStructuredMessageMicrosoftConsoleLogger = new PreStructuredMessageMicrosoftConsoleLogger(LogLevel);

        _fixedMessageSerilogConsoleLogger = new FixedMessageSerilogConsoleLogger(LogLevel);
        _preStructuredMessageSerilogConsoleLogger = new PreStructuredMessageSerilogConsoleLogger(LogLevel);
        _preInterpolatedMessageSerilogConsoleLogger = new PreInterpolatedMessageSerilogConsoleLogger(LogLevel);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftLoggerCategory)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        _fixedMessageMicrosoftConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory)]
    public void PreStructuredMessageMicrosoftConsoleLogger() =>
        _preStructuredMessageMicrosoftConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory)]
    public void PreInterpolatedMessageMicrosoftConsoleLogger() =>
        _preInterpolatedMessageMicrosoftConsoleLogger.Execute();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogLoggerCategory)]
    public void FixedMessageSerilogConsoleLogger() => 
        _fixedMessageSerilogConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogLoggerCategory)]
    public void PreStructuredMessageSerilogConsoleLogger() =>
        _preStructuredMessageSerilogConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogLoggerCategory)]
    public void PreInterpolatedMessageSerilogConsoleLogger() =>
        _preInterpolatedMessageSerilogConsoleLogger.Execute();
}
