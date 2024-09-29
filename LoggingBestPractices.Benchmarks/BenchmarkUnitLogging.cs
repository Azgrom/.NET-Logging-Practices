using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LoggingBestPractices.DefaultLogging;
using LoggingBestPractices.Serilogging;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

/// <summary>
///     Benchmarks Serilog versus Microsoft.Logging with and without Console sink. And with different message template
/// pre-processing styles
/// </summary>
[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class BenchmarkUnitLogging
{
    private const string SerilogEmptyLoggerCategory = "Serilog Empty Logger";
    private const string MicrosoftEmptyLoggerCategory = "Microsoft Empty Logger";
    private const string MicrosoftConsoleLoggerCategory = "Microsoft Console Logger";
    private const string SerilogConsoleLoggerCategory = "Serilog Console Logger";

    private FixedMessageMicrosoftConsoleLogger _fixedMessageMicrosoftConsoleLogger;
    private FixedMessageMicrosoftEmptyLogger _fixedMessageMicrosoftEmptyLogger;
    private FixedMessageSerilogConsoleLogger _fixedMessageSerilogConsoleLogger;
    private FixedMessageSerilogEmptyLogger _fixedMessageSerilogEmptyLogger;

    private PreInterpolatedMessageMicrosoftConsoleLogger _preInterpolatedMessageMicrosoftConsoleLogger;
    private PreInterpolatedMessageMicrosoftEmptyLogger _preInterpolatedMessageMicrosoftEmptyLogger;
    private PreInterpolatedMessageSerilogConsoleLogger _preInterpolatedMessageSerilogConsoleLogger;
    private PreInterpolatedMessageSerilogEmptyLogger _preInterpolatedMessageSerilogEmptyLogger;
    
    private PreStructuredMessageMicrosoftConsoleLogger _preStructuredMessageMicrosoftConsoleLogger;
    private PreStructuredMessageMicrosoftEmptyLogger _preStructuredMessageMicrosoftEmptyLogger;
    private PreStructuredMessageSerilogConsoleLogger _preStructuredMessageSerilogConsoleLogger;
    private PreStructuredMessageSerilogEmptyLogger _preStructuredMessageSerilogEmptyLogger;

    [Params(LogLevel.Information, LogLevel.Warning)]
    // ReSharper disable once FieldCanBeMadeReadOnly.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public LogLevel LogLevel;

    public BenchmarkUnitLogging(FixedMessageMicrosoftConsoleLogger fixedMessageMicrosoftConsoleLogger, FixedMessageMicrosoftEmptyLogger fixedMessageMicrosoftEmptyLogger, FixedMessageSerilogConsoleLogger fixedMessageSerilogConsoleLogger, FixedMessageSerilogEmptyLogger fixedMessageSerilogEmptyLogger, PreInterpolatedMessageMicrosoftConsoleLogger preInterpolatedMessageMicrosoftConsoleLogger, PreInterpolatedMessageMicrosoftEmptyLogger preInterpolatedMessageMicrosoftEmptyLogger, PreInterpolatedMessageSerilogConsoleLogger preInterpolatedMessageSerilogConsoleLogger, PreInterpolatedMessageSerilogEmptyLogger preInterpolatedMessageSerilogEmptyLogger, PreStructuredMessageMicrosoftConsoleLogger preStructuredMessageMicrosoftConsoleLogger, PreStructuredMessageMicrosoftEmptyLogger preStructuredMessageMicrosoftEmptyLogger, PreStructuredMessageSerilogConsoleLogger preStructuredMessageSerilogConsoleLogger, PreStructuredMessageSerilogEmptyLogger preStructuredMessageSerilogEmptyLogger, LogLevel logLevel)
    {
        _fixedMessageMicrosoftConsoleLogger = fixedMessageMicrosoftConsoleLogger;
        _fixedMessageMicrosoftEmptyLogger = fixedMessageMicrosoftEmptyLogger;
        _fixedMessageSerilogConsoleLogger = fixedMessageSerilogConsoleLogger;
        _fixedMessageSerilogEmptyLogger = fixedMessageSerilogEmptyLogger;
        _preInterpolatedMessageMicrosoftConsoleLogger = preInterpolatedMessageMicrosoftConsoleLogger;
        _preInterpolatedMessageMicrosoftEmptyLogger = preInterpolatedMessageMicrosoftEmptyLogger;
        _preInterpolatedMessageSerilogConsoleLogger = preInterpolatedMessageSerilogConsoleLogger;
        _preInterpolatedMessageSerilogEmptyLogger = preInterpolatedMessageSerilogEmptyLogger;
        _preStructuredMessageMicrosoftConsoleLogger = preStructuredMessageMicrosoftConsoleLogger;
        _preStructuredMessageMicrosoftEmptyLogger = preStructuredMessageMicrosoftEmptyLogger;
        _preStructuredMessageSerilogConsoleLogger = preStructuredMessageSerilogConsoleLogger;
        _preStructuredMessageSerilogEmptyLogger = preStructuredMessageSerilogEmptyLogger;
        LogLevel = logLevel;
    }

    [GlobalSetup]
    public void Setup()
    {
        _fixedMessageMicrosoftEmptyLogger = new FixedMessageMicrosoftEmptyLogger(LogLevel);
        _preInterpolatedMessageMicrosoftEmptyLogger = new PreInterpolatedMessageMicrosoftEmptyLogger(LogLevel);
        _preStructuredMessageMicrosoftEmptyLogger = new PreStructuredMessageMicrosoftEmptyLogger(LogLevel);

        _fixedMessageSerilogEmptyLogger = new FixedMessageSerilogEmptyLogger(LogLevel);
        _preInterpolatedMessageSerilogEmptyLogger = new PreInterpolatedMessageSerilogEmptyLogger(LogLevel);
        _preStructuredMessageSerilogEmptyLogger = new PreStructuredMessageSerilogEmptyLogger(LogLevel);

        _fixedMessageMicrosoftConsoleLogger = new FixedMessageMicrosoftConsoleLogger(LogLevel);
        _preInterpolatedMessageMicrosoftConsoleLogger = new PreInterpolatedMessageMicrosoftConsoleLogger(LogLevel);
        _preStructuredMessageMicrosoftConsoleLogger = new PreStructuredMessageMicrosoftConsoleLogger(LogLevel);

        _fixedMessageSerilogConsoleLogger = new FixedMessageSerilogConsoleLogger(LogLevel);
        _preStructuredMessageSerilogConsoleLogger = new PreStructuredMessageSerilogConsoleLogger(LogLevel);
        _preInterpolatedMessageSerilogConsoleLogger = new PreInterpolatedMessageSerilogConsoleLogger(LogLevel);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void FixedMessageMicrosoftEmptyLogger() =>
        _fixedMessageMicrosoftEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        _preInterpolatedMessageMicrosoftEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        _preStructuredMessageMicrosoftEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogEmptyLoggerCategory)]
    public void FixedMessageSerilogEmptyLogger() =>
        _fixedMessageSerilogEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogEmptyLoggerCategory)]
    public void PreInterpolatedSerilogEmptyLogger() =>
        _preInterpolatedMessageSerilogEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogEmptyLoggerCategory)]
    public void PreStructuredSerilogEmptyLogger() =>
        _preStructuredMessageSerilogEmptyLogger.Execute();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        _fixedMessageMicrosoftConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void PreInterpolatedMessageMicrosoftConsoleLogger() =>
        _preInterpolatedMessageMicrosoftConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void PreStructuredMessageMicrosoftConsoleLogger() =>
        _preStructuredMessageMicrosoftConsoleLogger.Execute();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogConsoleLoggerCategory)]
    public void FixedMessageSerilogConsoleLogger() =>
        _fixedMessageSerilogConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogConsoleLoggerCategory)]
    public void PreStructuredMessageSerilogConsoleLogger() =>
        _preStructuredMessageSerilogConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogConsoleLoggerCategory)]
    public void PreInterpolatedMessageSerilogConsoleLogger() =>
        _preInterpolatedMessageSerilogConsoleLogger.Execute();
}
