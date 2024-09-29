using BenchmarkDotNet.Running;
using LoggingBestPractices.Benchmarks;

// var summary = BenchmarkRunner.Run<BenchmarkLoadLogging>();
var run = BenchmarkRunner.Run<BenchmarkUnitLogging>();

// summary.
