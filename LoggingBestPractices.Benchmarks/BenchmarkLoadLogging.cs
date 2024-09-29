using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using LoggingBestPractices.DefaultLogging;
using LoggingBestPractices.Serilogging;

namespace LoggingBestPractices.Benchmarks;

[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RunStrategy.Monitoring, RuntimeMoniker.Net80)]
public class BenchmarkLoadLogging
{
    private const string EmptySink = "Empty sink";
    private const string Console = "Writes to Console";
    private const string Serilog = "Serilog";
    private const string MicrosoftLogger = "Microsoft.Logger";
    private static readonly Random Random = new();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(Serilog, EmptySink)]
    public void FixedMessageSerilogEmptyLogger() =>
        Serilogging.FixedMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(Serilog, EmptySink)]
    public void PreInterpolatedSerilogEmptyLogger() =>
        PreInterpolatedMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(Serilog, EmptySink)]
    public void PreStructuredSerilogEmptyLogger() =>
        PreStructuredMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(Serilog, Console)]
    public void FixedMessageSerilogConsoleLogger() =>
        Serilogging.FixedMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(Serilog, Console)]
    public void PreInterpolatedSerilogConsoleLogger() =>
        PreInterpolatedMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(Serilog, Console)]
    public void PreStructuredSerilogConsoleLogger() =>
        PreStructuredMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, EmptySink)]
    public void FixedMessageMicrosoftEmptyLogger() =>
        DefaultLogging.FixedMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, EmptySink)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        PreInterpolatedMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, EmptySink)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        PreStructuredMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, Console)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        DefaultLogging.FixedMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, Console)]
    public void PreInterpolatedMicrosoftConsoleLogger() =>
        PreInterpolatedMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, Console)]
    public void PreStructuredMicrosoftConsoleLogger() =>
        StructuredMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning(Random.Next);
}
