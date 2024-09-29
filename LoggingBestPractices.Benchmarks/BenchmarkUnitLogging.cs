using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using LoggingBestPractices.DefaultLogging;
using LoggingBestPractices.Serilogging;
using Microsoft.Extensions.Logging;
// ReSharper disable UnassignedField.Global
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

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
    private static readonly Random Random = new();

    private FixedMessageMicrosoftConsoleLogger _fixedMessageMicrosoftConsoleLogger;
    private FixedMessageMicrosoftEmptyLogger _fixedMessageMicrosoftEmptyLogger;
    private FixedMessageSerilogConsoleLogger _fixedMessageSerilogConsoleLogger;
    private FixedMessageSerilogEmptyLogger _fixedMessageSerilogEmptyLogger;

    private InterpolatedMessageMicrosoftConsoleLogger _preInterpolatedMessageMicrosoftConsoleLogger;
    private InterpolatedMessageMicrosoftEmptyLogger _preInterpolatedMessageMicrosoftEmptyLogger;
    private InterpolatedMessageSerilogConsoleLogger _preInterpolatedMessageSerilogConsoleLogger;
    private InterpolatedMessageSerilogEmptyLogger _preInterpolatedMessageSerilogEmptyLogger;
    
    private StructuredMessageMicrosoftConsoleLogger _preStructuredMessageMicrosoftConsoleLogger;
    private StructuredMessageMicrosoftEmptyLogger _preStructuredMessageMicrosoftEmptyLogger;
    private StructuredMessageSerilogConsoleLogger _preStructuredMessageSerilogConsoleLogger;
    private StructuredMessageSerilogEmptyLogger _preStructuredMessageSerilogEmptyLogger;

    [Params(LogLevel.Information, LogLevel.Warning)]
    public LogLevel LogLevel;

    [GlobalSetup]
    public void Setup()
    {
        _fixedMessageMicrosoftEmptyLogger = new FixedMessageMicrosoftEmptyLogger(LogLevel);
        _preInterpolatedMessageMicrosoftEmptyLogger = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel);
        _preStructuredMessageMicrosoftEmptyLogger = new StructuredMessageMicrosoftEmptyLogger(LogLevel);

        _fixedMessageSerilogEmptyLogger = new FixedMessageSerilogEmptyLogger(LogLevel);
        _preInterpolatedMessageSerilogEmptyLogger = new InterpolatedMessageSerilogEmptyLogger(LogLevel);
        _preStructuredMessageSerilogEmptyLogger = new StructuredMessageSerilogEmptyLogger(LogLevel);

        _fixedMessageMicrosoftConsoleLogger = new FixedMessageMicrosoftConsoleLogger(LogLevel);
        _preInterpolatedMessageMicrosoftConsoleLogger = new InterpolatedMessageMicrosoftConsoleLogger(LogLevel);
        _preStructuredMessageMicrosoftConsoleLogger = new StructuredMessageMicrosoftConsoleLogger(LogLevel);

        _fixedMessageSerilogConsoleLogger = new FixedMessageSerilogConsoleLogger(LogLevel);
        _preStructuredMessageSerilogConsoleLogger = new StructuredMessageSerilogConsoleLogger(LogLevel);
        _preInterpolatedMessageSerilogConsoleLogger = new InterpolatedMessageSerilogConsoleLogger(LogLevel);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void FixedMessageMicrosoftEmptyLogger() =>
        _fixedMessageMicrosoftEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        _preInterpolatedMessageMicrosoftEmptyLogger.Execute(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        _preStructuredMessageMicrosoftEmptyLogger.Execute(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogEmptyLoggerCategory)]
    public void FixedMessageSerilogEmptyLogger() =>
        _fixedMessageSerilogEmptyLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogEmptyLoggerCategory)]
    public void PreInterpolatedSerilogEmptyLogger() =>
        _preInterpolatedMessageSerilogEmptyLogger.Execute(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogEmptyLoggerCategory)]
    public void PreStructuredSerilogEmptyLogger() =>
        _preStructuredMessageSerilogEmptyLogger.Execute(Random.Next);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        _fixedMessageMicrosoftConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void PreInterpolatedMessageMicrosoftConsoleLogger() =>
        _preInterpolatedMessageMicrosoftConsoleLogger.Execute(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void PreStructuredMessageMicrosoftConsoleLogger() =>
        _preStructuredMessageMicrosoftConsoleLogger.Execute(Random.Next);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogConsoleLoggerCategory)]
    public void FixedMessageSerilogConsoleLogger() =>
        _fixedMessageSerilogConsoleLogger.Execute();

    [Benchmark]
    [BenchmarkCategory(SerilogConsoleLoggerCategory)]
    public void PreStructuredMessageSerilogConsoleLogger() =>
        _preStructuredMessageSerilogConsoleLogger.Execute(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogConsoleLoggerCategory)]
    public void PreInterpolatedMessageSerilogConsoleLogger() =>
        _preInterpolatedMessageSerilogConsoleLogger.Execute(Random.Next);
}
