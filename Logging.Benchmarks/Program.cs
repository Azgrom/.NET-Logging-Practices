using BenchmarkDotNet.Running;
using Logging.Benchmarks;

// var summary = BenchmarkRunner.Run<BenchmarkLoadLogging>();

var run       = BenchmarkRunner.Run([typeof(BenchmarkUnitLogging), typeof(BenchmarkUnitMicrosoftLogger)]);
var summaries = run.ToList();
Console.WriteLine();

// summary.
