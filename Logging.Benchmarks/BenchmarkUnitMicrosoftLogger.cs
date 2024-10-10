using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using Microsoft.Extensions.Logging;
using Microsoft.Logs;
// ReSharper disable UnassignedField.Global

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace Logging.Benchmarks;

/// <summary>
///     Benchmarks Serilog versus Microsoft.Logging with and without Console sink. And with different message template
///     pre-processing styles
/// </summary>
[RPlotExporter]
[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RuntimeMoniker.Net80)]
public class BenchmarkUnitMicrosoftLogger
{
    private const string MicrosoftEmptyLoggerCategory   = "Microsoft Empty Logger";
    private const string MicrosoftConsoleLoggerCategory = "Microsoft Console Logger";
    private const int    RandomFixedNumber              = 3149215;

    private FixedMessageMicrosoftConsoleLogger _fixedMessageMicrosoftConsoleLogger;
    private FixedMessageMicrosoftEmptyLogger   _fixedMessageMicrosoftEmptyLogger;

    private InterpolatedMessageMicrosoftConsoleLogger _preInterpolatedMessageMicrosoftConsoleLogger;
    private InterpolatedMessageMicrosoftEmptyLogger   _preInterpolatedMessageMicrosoftEmptyLogger;

    private StructuredMessageMicrosoftConsoleLogger _preStructuredMessageMicrosoftConsoleLogger;
    private StructuredMessageMicrosoftEmptyLogger   _preStructuredMessageMicrosoftEmptyLogger;

    [Params(LogLevel.Information, LogLevel.Warning)]
    public LogLevel LogLevel;

    [GlobalSetup]
    public void Setup()
    {
        _fixedMessageMicrosoftEmptyLogger   = new FixedMessageMicrosoftEmptyLogger(LogLevel);
        _fixedMessageMicrosoftConsoleLogger = new FixedMessageMicrosoftConsoleLogger(LogLevel);

        _preInterpolatedMessageMicrosoftEmptyLogger   = new InterpolatedMessageMicrosoftEmptyLogger(LogLevel);
        _preInterpolatedMessageMicrosoftConsoleLogger = new InterpolatedMessageMicrosoftConsoleLogger(LogLevel);

        _preStructuredMessageMicrosoftEmptyLogger   = new StructuredMessageMicrosoftEmptyLogger(LogLevel);
        _preStructuredMessageMicrosoftConsoleLogger = new StructuredMessageMicrosoftConsoleLogger(LogLevel);
    }

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void FixedMessageMicrosoftEmptyLogger() => _fixedMessageMicrosoftEmptyLogger.ExecuteInformation();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void FixedMessageMicrosoftConsoleLogger() => _fixedMessageMicrosoftConsoleLogger.ExecuteInformation();

    [Benchmark]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        _preInterpolatedMessageMicrosoftEmptyLogger.ExecuteInformation(RandomFixedNumber);

    [Benchmark]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void PreInterpolatedMessageMicrosoftConsoleLogger() =>
        _preInterpolatedMessageMicrosoftConsoleLogger.ExecuteInformation(RandomFixedNumber);

    [Benchmark]
    [BenchmarkCategory(MicrosoftEmptyLoggerCategory)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        _preStructuredMessageMicrosoftEmptyLogger.ExecuteInformation(RandomFixedNumber);

    [Benchmark]
    [BenchmarkCategory(MicrosoftConsoleLoggerCategory)]
    public void PreStructuredMessageMicrosoftConsoleLogger() =>
        _preStructuredMessageMicrosoftConsoleLogger.ExecuteInformation(RandomFixedNumber);
}
