using Configurations;
using LoggingBestPractices.Benchmarks;

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Formatted_SerilogLogger_Without_If_WithParams();
}
