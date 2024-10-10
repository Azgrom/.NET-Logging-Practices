using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Microsoft.Logs;
using Serilog.Logs;

namespace Logging.Benchmarks;

[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RunStrategy.Monitoring, RuntimeMoniker.Net80)]
public class BenchmarkLoadLogging
{
    private const           string EmptySinkCategory       = "Empty sink";
    private const           string ConsoleCategory         = "Writes to Console";
    private const           string SerilogCategory         = "Serilog";
    private const           string MicrosoftLoggerCategory = "Microsoft.Logger";
    private static readonly Random Random                  = new();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogCategory, EmptySinkCategory)]
    public void FixedMessageSerilogEmptyLogger() =>
        Serilog.Logs.FixedMessageSerilogEmptyLogger.IterateExecutionNMillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, EmptySinkCategory)]
    public void PreInterpolatedSerilogEmptyLogger() =>
        InterpolatedMessageSerilogEmptyLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, EmptySinkCategory)]
    public void PreStructuredSerilogEmptyLogger() =>
        StructuredMessageSerilogEmptyLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogCategory, ConsoleCategory)]
    public void FixedMessageSerilogConsoleLogger() =>
        Serilog.Logs.FixedMessageSerilogConsoleLogger.IterateExecutionNMillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, ConsoleCategory)]
    public void PreInterpolatedSerilogConsoleLogger() =>
        InterpolatedMessageSerilogConsoleLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, ConsoleCategory)]
    public void PreStructuredSerilogConsoleLogger() =>
        StructuredMessageSerilogConsoleLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, EmptySinkCategory)]
    public void FixedMessageMicrosoftEmptyLogger() =>
        Microsoft.Logs.FixedMessageMicrosoftEmptyLogger.IterateExecutionNMillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, EmptySinkCategory)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        InterpolatedMessageMicrosoftEmptyLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, EmptySinkCategory)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        StructuredMessageMicrosoftEmptyLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, ConsoleCategory)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        Microsoft.Logs.FixedMessageMicrosoftConsoleLogger.IterateExecutionNMillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, ConsoleCategory)]
    public void PreInterpolatedMicrosoftConsoleLogger() =>
        InterpolatedMessageMicrosoftConsoleLogger.IterateExecutionNMillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, ConsoleCategory)]
    public void PreStructuredMicrosoftConsoleLogger() =>
        StructuredMessageMicrosoftConsoleLogger.IterateExecutionNMillionTimes_Warning(Random.Next);
}
