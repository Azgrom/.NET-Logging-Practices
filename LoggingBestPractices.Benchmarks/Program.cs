using BenchmarkDotNet.Running;
using LoggingBestPractices.Benchmarks;
using LoggingBestPractices.DefaultLogging;

// var summary = BenchmarkRunner.Run<BenchmarkLoadLogging>();

var run        = BenchmarkRunner.Run<BenchmarkUnitMicrosoftLogger>();
var runOrderer = run.Orderer;

Console.WriteLine();

// summary.
