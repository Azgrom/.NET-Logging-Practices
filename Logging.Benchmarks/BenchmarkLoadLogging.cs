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
    private const string EmptySinkCategory = "Empty sink";
    private const string ConsoleCategory = "Writes to Console";
    private const string SerilogCategory = "Serilog";
    private const string MicrosoftLoggerCategory = "Microsoft.Logger";
    private static readonly Random Random = new();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogCategory, EmptySinkCategory)]
    public void FixedMessageSerilogEmptyLogger() =>
        Serilog.Logs.FixedMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, EmptySinkCategory)]
    public void PreInterpolatedSerilogEmptyLogger() =>
        InterpolatedMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, EmptySinkCategory)]
    public void PreStructuredSerilogEmptyLogger() =>
        StructuredMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(SerilogCategory, ConsoleCategory)]
    public void FixedMessageSerilogConsoleLogger() =>
        Serilog.Logs.FixedMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, ConsoleCategory)]
    public void PreInterpolatedSerilogConsoleLogger() =>
        InterpolatedMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(SerilogCategory, ConsoleCategory)]
    public void PreStructuredSerilogConsoleLogger() =>
        StructuredMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, EmptySinkCategory)]
    public void FixedMessageMicrosoftEmptyLogger() =>
        Microsoft.Logs.FixedMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, EmptySinkCategory)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        InterpolatedMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, EmptySinkCategory)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        StructuredMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, ConsoleCategory)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        Microsoft.Logs.FixedMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, ConsoleCategory)]
    public void PreInterpolatedMicrosoftConsoleLogger() =>
        InterpolatedMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLoggerCategory, ConsoleCategory)]
    public void PreStructuredMicrosoftConsoleLogger() =>
        StructuredMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);
}
