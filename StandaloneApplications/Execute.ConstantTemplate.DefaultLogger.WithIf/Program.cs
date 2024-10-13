using Configurations;
using LoggingBestPractices.Benchmarks;

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (var i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.ConstantTemplate_DefaultLogger_With_If();
}
