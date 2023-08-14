using BenchmarkDotNet.Running;
using LoggingBestPractices.Benchmarks;

var summary = BenchmarkRunner.Run<Benchmarks>();
