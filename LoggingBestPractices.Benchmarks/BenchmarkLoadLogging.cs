using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using LoggingBestPractices.DefaultLogging;
using LoggingBestPractices.Serilogging;
using Microsoft.Extensions.Logging;

namespace LoggingBestPractices.Benchmarks;

[CategoriesColumn]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[MemoryDiagnoser]
[SimpleJob(RunStrategy.Monitoring, RuntimeMoniker.Net70)]
public class BenchmarkLoadLogging
{
    private const string EmptySink = "Empty sink";
    private const string Console = "Writes to Console";
    private const string Serilog = "Serilog";
    private const string MicrosoftLogger = "Microsoft.Logger";

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(Serilog, EmptySink)]
    public void FixedMessageSerilogEmptyLogger() =>
        Serilogging.FixedMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(Serilog, EmptySink)]
    public void PreInterpolatedSerilogEmptyLogger() =>
        PreInterpolatedMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(Serilog, EmptySink)]
    public void PreStructuredSerilogEmptyLogger() =>
        PreStructuredMessageSerilogEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark(Baseline = true)]
    [BenchmarkCategory(Serilog, Console)]
    public void FixedMessageSerilogConsoleLogger() =>
        Serilogging.FixedMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(Serilog, Console)]
    public void PreInterpolatedSerilogConsoleLogger() =>
        PreInterpolatedMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(Serilog, Console)]
    public void PreStructuredSerilogConsoleLogger() =>
        PreStructuredMessageSerilogConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, EmptySink)]
    public void FixedMessageMicrosoftEmptyLogger() =>
        DefaultLogging.FixedMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, EmptySink)]
    public void PreInterpolatedMicrosoftEmptyLogger() =>
        PreInterpolatedMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, EmptySink)]
    public void PreStructuredMicrosoftEmptyLogger() =>
        PreStructuredMessageMicrosoftEmptyLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, Console)]
    public void FixedMessageMicrosoftConsoleLogger() =>
        DefaultLogging.FixedMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, Console)]
    public void PreInterpolatedMicrosoftConsoleLogger() =>
        PreInterpolatedMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning();

    [Benchmark]
    [BenchmarkCategory(MicrosoftLogger, Console)]
    public void PreStructuredMicrosoftConsoleLogger() =>
        PreStructuredMessageMicrosoftConsoleLogger.IterateExecution100MillionTimes_Warning();
}
