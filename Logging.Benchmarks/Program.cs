using BenchmarkDotNet.Running;
using Logging.Benchmarks;

// var summary = BenchmarkRunner.Run<BenchmarkLoadLogging>();

var run        = BenchmarkRunner.Run<BenchmarkUnitMicrosoftLogger>();
var runOrderer = run.Orderer;

Console.WriteLine();

// summary.
