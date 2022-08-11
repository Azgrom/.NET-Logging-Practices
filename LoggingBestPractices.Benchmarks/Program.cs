using BenchmarkDotNet.Running;

namespace LoggingBestPractices.Benchmarks;

public static class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<Benchmarks>();
    }
}
