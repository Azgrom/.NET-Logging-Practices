using BenchmarkDotNet.Running;
using Logging.Benchmarks;
using LoggingBestPractices.DefaultLogging;

// var summary = BenchmarkRunner.Run<BenchmarkLoadLogging>();

var run        = BenchmarkRunner.Run<BenchmarkUnitMicrosoftLogger>();
var runOrderer = run.Orderer;

Console.WriteLine();

// summary.
