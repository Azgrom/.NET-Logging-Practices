using Configurations;
using LoggingBestPractices.Benchmarks;

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Parameterized_DefaultLogger_Without_If_WithParams();
}
