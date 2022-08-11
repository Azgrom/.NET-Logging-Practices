using BenchmarkDotNet.Running;

namespace LoggingBestPractices.Benchmarks;

public class Program
{
    public static void Main()
    {
        var summary = BenchmarkRunner.Run<Benchmarks>();
    }
}
