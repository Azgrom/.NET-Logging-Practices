using Configurations;
using LoggingBestPractices.Benchmarks;

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.ConstantTemplate_SerilogLogger_With_If();
}
