# Standalone Applications Memory Profiling

```

BenchmarkDotNet v0.13.7, elementary OS 7.1 Horus
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 8.0.403
  [Host]     : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.10 (8.0.1024.46610), X64 RyuJIT AVX2


```
|                                            Method |        Mean |     Error |    StdDev | Completed Work Items | Lock Contentions |   Gen0 | Allocated |
|-------------------------------------------------- |------------:|----------:|----------:|---------------------:|-----------------:|-------:|----------:|
|         ConstantTemplate_DefaultLogger_Without_If |  37.1928 ns | 0.4846 ns | 0.4533 ns |                    - |                - |      - |         - |
|            ConstantTemplate_DefaultLogger_With_If |   7.4783 ns | 0.1336 ns | 0.1184 ns |                    - |                - |      - |         - |
| Parameterized_DefaultLogger_Without_If_WithParams | 112.6148 ns | 1.0148 ns | 0.9493 ns |                    - |                - | 0.0191 |     120 B |
|    Parameterized_DefaultLogger_With_If_WithParams |   7.7565 ns | 0.0596 ns | 0.0558 ns |                    - |                - |      - |         - |
|     Formatted_DefaultLogger_Without_If_WithParams | 197.3810 ns | 2.0268 ns | 1.8959 ns |                    - |                - | 0.0305 |     192 B |
|        Formatted_DefaultLogger_With_If_WithParams |   7.2926 ns | 0.0197 ns | 0.0175 ns |                    - |                - |      - |         - |
|  Interpolated_DefaultLogger_Without_If_WithParams | 137.7394 ns | 0.2748 ns | 0.2295 ns |                    - |                - | 0.0203 |     128 B |
|     Interpolated_DefaultLogger_With_If_WithParams |   7.3041 ns | 0.0382 ns | 0.0338 ns |                    - |                - |      - |         - |
|         ConstantTemplate_SerilogLogger_Without_If |   1.7583 ns | 0.0270 ns | 0.0226 ns |                    - |                - |      - |         - |
|            ConstantTemplate_SerilogLogger_With_If |   0.1587 ns | 0.0019 ns | 0.0015 ns |                    - |                - |      - |         - |
| Parameterized_SerilogLogger_Without_If_WithParams |   8.2585 ns | 0.0397 ns | 0.0351 ns |                    - |                - |      - |         - |
|    Parameterized_SerilogLogger_With_If_WithParams |   0.1724 ns | 0.0040 ns | 0.0035 ns |                    - |                - |      - |         - |
|     Formatted_SerilogLogger_Without_If_WithParams | 158.5146 ns | 0.1690 ns | 0.1498 ns |                    - |                - | 0.0305 |     192 B |
|        Formatted_SerilogLogger_With_If_WithParams |   0.6331 ns | 0.0019 ns | 0.0018 ns |                    - |                - |      - |         - |
|  Interpolated_SerilogLogger_Without_If_WithParams |  99.7871 ns | 0.2268 ns | 0.2011 ns |                    - |                - | 0.0204 |     128 B |
|     Interpolated_SerilogLogger_With_If_WithParams |   1.1581 ns | 0.0272 ns | 0.0255 ns |                    - |                - |      - |         - |
// * Hints *
Outliers
CompareEmptyLogsBenchmark.ConstantTemplate_DefaultLogger_With_If: Default            -> 1 outlier  was  removed (10.86 ns)
CompareEmptyLogsBenchmark.Formatted_DefaultLogger_With_If_WithParams: Default        -> 1 outlier  was  removed (9.89 ns)
CompareEmptyLogsBenchmark.Interpolated_DefaultLogger_Without_If_WithParams: Default  -> 2 outliers were removed (142.13 ns, 142.27 ns)
CompareEmptyLogsBenchmark.ConstantTemplate_SerilogLogger_Without_If: Default         -> 2 outliers were removed (4.34 ns, 4.38 ns)
CompareEmptyLogsBenchmark.ConstantTemplate_SerilogLogger_With_If: Default            -> 2 outliers were removed (2.65 ns, 2.75 ns)
CompareEmptyLogsBenchmark.Parameterized_SerilogLogger_Without_If_WithParams: Default -> 1 outlier  was  removed (10.84 ns)
CompareEmptyLogsBenchmark.Parameterized_SerilogLogger_With_If_WithParams: Default    -> 1 outlier  was  removed (2.67 ns)
CompareEmptyLogsBenchmark.Formatted_SerilogLogger_Without_If_WithParams: Default     -> 1 outlier  was  removed (162.81 ns)
CompareEmptyLogsBenchmark.Interpolated_SerilogLogger_Without_If_WithParams: Default  -> 1 outlier  was  removed (108.14 ns)

// * Legends *
Mean                 : Arithmetic mean of all measurements
Error                : Half of 99.9% confidence interval
StdDev               : Standard deviation of all measurements
Completed Work Items : The number of work items that have been processed in ThreadPool (per single operation)
Lock Contentions     : The number of times there was contention upon trying to take a Monitor's lock (per single operation)
Gen0                 : GC Generation 0 collects per 1000 operations
Allocated            : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
1 ns                 : 1 Nanosecond (0.000000001 sec)

// * Diagnostic Output - ThreadingDiagnoser *

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:06:38 (398.96 sec), executed benchmarks: 16

Global total time: 00:07:54 (474.71 sec), executed benchmarks: 16
// * Artifacts cleanup *
Artifacts cleanup is finished

```csharp
public static class Constants
{
    public const int Iterations = 1_000_000;
}

public class CompareEmptyLogsBenchmark
{
    private readonly ILogger<CompareEmptyLogsBenchmark> _defaultLogger;
    private readonly LoggerConfiguration                _loggerConfiguration = new();
    private readonly ILoggerFactory _loggerFactory
        = LoggerFactory.Create(builder => builder.AddConsole().SetMinimumLevel(LogLevel.Warning));
    private readonly ILogger _serilogLogger;

    public CompareEmptyLogsBenchmark()
    {
        _defaultLogger = new Logger<CompareEmptyLogsBenchmark>(_loggerFactory);
        _serilogLogger = _loggerConfiguration.MinimumLevel.Warning().CreateLogger();
    }
}
```


## Constant Template Runs

### Default Logger Checking LogLevel

```c#
public void ConstantTemplate_DefaultLogger_With_If()
{
    if (_defaultLogger.IsEnabled(LogLevel.Information)) 
        _defaultLogger.LogInformation("Fixed Log Message");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (var i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.ConstantTemplate_DefaultLogger_With_If();
}
```

```shell
$ timeit ./Execute.ConstantTemplate.DefaultLogger.WithIf/bin/Release/net8.0/Execute.ConstantTemplate.DefaultLogger.WithIf 
190ms 127µs 245ns
```

![image-20241013202319837](./docs/ConstantTemplate.DefaultLogger.WithIf.png)

### Default Logger Not Checking LogLevel

```c#
public void ConstantTemplate_DefaultLogger_Without_If()
{
    _defaultLogger.LogInformation("Fixed Log Message");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.ConstantTemplate_DefaultLogger_Without_If();
}
```

```shell
$ timeit ./Execute.ConstantTemplate.DefaultLogger.WithoutIf/bin/Release/net8.0/Execute.ConstantTemplate.DefaultLogger.WithoutIf 
228ms 753µs 872ns
```

![image-20241013202533113](./docs/ConstantTemplate.DefaultLogger.WithoutIf.png)

### Serilog Logger Checking LogLevel

```c#
public void ConstantTemplate_SerilogLogger_With_If()
{
    if (_serilogLogger.IsEnabled(LogEventLevel.Information)) _serilogLogger.Information("Fixed Log Message");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.ConstantTemplate_SerilogLogger_With_If();
}
```

```shell
$ timeit ./Execute.ConstantTemplate.SerilogLogger.WithIf/bin/Release/net8.0/Execute.ConstantTemplate.SerilogLogger.WithIf 
154ms 164µs 306ns
```

![image-20241013202715299](./docs/ConstantTemplate.SerilogLogger.WithIf.png)

### Serilog Logger Not Checking LogLevel

```c#
public void ConstantTemplate_SerilogLogger_Without_If() 
{ 
    _serilogLogger.Information("Fixed Log Message"); 
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.ConstantTemplate_SerilogLogger_Without_If();
}
```

```shell
$ timeit ./Execute.ConstantTemplate.SerilogLogger.WithoutIf/bin/Release/net8.0/Execute.ConstantTemplate.SerilogLogger.WithoutIf 
153ms 982µs 609ns
```

![image-20241013202740898](./docs/ConstantTemplate.SerilogLogger.WithoutIf.png)



## Parameterized Template Runs

### Default Logger Checking LogLevel

```c#
public void Parameterized_DefaultLogger_With_If_WithParams()
{
    if (_defaultLogger.IsEnabled(LogLevel.Information))
        _defaultLogger.LogInformation("This is a log message with parameters {0}, {1} and {2}", 40, 70, 175);
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Parameterized_DefaultLogger_With_If_WithParams();
}
```

```shell
$ timeit ./Execute.ParameterizedTemplate.DefaultLogger.WithIf/bin/Release/net8.0/Execute.ParameterizedTemplate.DefaultLogger.WithIf 
190ms 213µs 856ns
```

![image-20241013203902964](./docs/ParameterizedTemplate.DefaultLogger.WithIf.png)

### Default Logger Not Checking LogLevel

```c#
public void Parameterized_DefaultLogger_Without_If_WithParams()
{
    _defaultLogger.LogInformation("This is a log message with parameters {0}, {1} and {2}", 50, 75, 125);
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Parameterized_DefaultLogger_Without_If_WithParams();
}
```

```shell
$ timeit ./Execute.ParameterizedTemplate.DefaultLogger.WithoutIf/bin/Release/net8.0/Execute.ParameterizedTemplate.DefaultLogger.WithoutIf 
325ms 668µs 9ns
```

![image-20241013203955144](./docs/ParameterizedTemplate.DefaultLogger.WithoutIf1.png)

![image-20241013204021988](./docs/ParameterizedTemplate.DefaultLogger.WithoutIf2.png)

### Serilog Logger Checking LogLevel

```c#
public void Parameterized_SerilogLogger_With_If_WithParams()
{
    if (_serilogLogger.IsEnabled(LogEventLevel.Information))
        _serilogLogger.Information("This is a log message with parameters {0}, {1} and {2}", 40, 70, 175);
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Parameterized_SerilogLogger_With_If_WithParams();
}
```

```shell
$ timeit ./Execute.ParameterizedTemplate.SerilogLogger.WithIf/bin/Release/net8.0/Execute.ParameterizedTemplate.SerilogLogger.WithIf 
151ms 171µs 873ns
```

![image-20241013204048226](./docs/ParameterizedTemplate.SerilogLogger.WithIf.png)

### Serilog Logger Not Checking LogLevel

```c#
public void Parameterized_SerilogLogger_Without_If_WithParams()
{
    _serilogLogger.Information("This is a log message with parameters {0}, {1} and {2}", 50, 75, 125);
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Parameterized_SerilogLogger_Without_If_WithParams();
}
```

```shell
$ timeit ./Execute.ParameterizedTemplate.SerilogLogger.WithoutIf/bin/Release/net8.0/Execute.ParameterizedTemplate.SerilogLogger.WithoutIf 
157ms 636µs 13ns
```

![image-20241013204129100](./docs/ParameterizedTemplate.SerilogLogger.WithoutIf.png)



## Formatted Template Runs

### Default Logger Checking LogLevel

```c#
public void Formatted_DefaultLogger_With_If_WithParams()
{
    if (_defaultLogger.IsEnabled(LogLevel.Information))
        _defaultLogger.LogInformation(string.Format("This is a log message with parameters {0}, {1} and {2}", 5, 7, 2));
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Formatted_DefaultLogger_With_If_WithParams();
}
```

```shell
$ timeit ./Execute.FormattedTemplate.DefaultLogger.WithIf/bin/Release/net8.0/Execute.FormattedTemplate.DefaultLogger.WithIf 
189ms 633µs 888ns
```

![image-20241013202854560](./docs/FormattedTemplate.DefaultLogger.WithIf.png)

### Default Logger Not Checking LogLevel

```c#
public void Formatted_DefaultLogger_Without_If_WithParams()
{
    _defaultLogger.LogInformation(string.Format("This is a log message with parameters {0}, {1} and {2}", 5, 7, 2));
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Formatted_DefaultLogger_Without_If_WithParams();
}
```

```shell
$ timeit ./Execute.FormattedTemplate.DefaultLogger.WithoutIf/bin/Release/net8.0/Execute.FormattedTemplate.DefaultLogger.WithoutIf 
496ms 237µs 952ns
```

![image-20241013202936256](./docs/FormattedTemplate.DefaultLogger.WithoutIf0.png)

![image-20241013202953388](./docs/FormattedTemplate.DefaultLogger.WithoutIf1.png)

![image-20241013203023301](./docs/FormattedTemplate.DefaultLogger.WithoutIf2.png)

### Serilog Logger Checking LogLevel

```c#
public void Formatted_SerilogLogger_With_If_WithParams()
{
    if (_serilogLogger.IsEnabled(LogEventLevel.Information))
        _serilogLogger.Information(string.Format("This is a log message with parameters {0}, {1} and {2}", 5, 7, 2));
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Formatted_SerilogLogger_With_If_WithParams();
}
```

```shell
$ timeit ./Execute.FormattedTemplate.SerilogLogger.WithIf/bin/Release/net8.0/Execute.FormattedTemplate.SerilogLogger.WithIf 
152ms 909µs 233ns
```

![image-20241013203107938](./docs/FormattedTemplate.SerilogLogger.WithIf.png)

### Serilog Logger Not Checking LogLevel

```c#
public void Formatted_SerilogLogger_Without_If_WithParams()
{
    _serilogLogger.Information(string.Format("This is a log message with parameters {0}, {1} and {2}", 5, 7, 2));
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Formatted_SerilogLogger_Without_If_WithParams();
}
```

````shell
$ timeit ./Execute.FormattedTemplate.SerilogLogger.WithoutIf/bin/Release/net8.0/Execute.FormattedTemplate.SerilogLogger.WithoutIf 
354ms 197µs 408ns
````

![image-20241013203158005](./docs/FormattedTemplate.SerilogLogger.WithoutIf1.png)

![image-20241013203223560](./docs/FormattedTemplate.SerilogLogger.WithoutIf2.png)

## Interpolated Template Runs

### Default Logger Checking LogLevel

```c#
public void Interpolated_DefaultLogger_With_If_WithParams()
{
    if (_defaultLogger.IsEnabled(LogLevel.Information))
        _defaultLogger.LogInformation($"This is a log message with parameters {464}, {4542}, {0}");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Interpolated_DefaultLogger_With_If_WithParams();
}
```

```shell
$ timeit ./Execute.InterpolatedTemplate.DefaultLogger.WithIf/bin/Release/net8.0/Execute.InterpolatedTemplate.DefaultLogger.WithIf 
190ms 567µs 102ns
```

![image-20241013203334150](./docs/InterpolatedTemplate.DefaultLogger.WithIf.png)

### Default Logger Not Checking LogLevel

```c#
public void Interpolated_DefaultLogger_Without_If_WithParams()
{
    _defaultLogger.LogInformation($"This is a log message with parameters {464}, {4542}, {0}");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Interpolated_DefaultLogger_Without_If_WithParams();
}
```

```shell
$ timeit ./Execute.InterpolatedTemplate.DefaultLogger.WithoutIf/bin/Release/net8.0/Execute.InterpolatedTemplate.DefaultLogger.WithoutIf 
453ms 985µs 282ns
```

![image-20241013203413926](./docs/InterpolatedTemplate.DefaultLogger.WithoutIf1.png)

![image-20241013204400438](./docs/InterpolatedTemplate.DefaultLogger.WithoutIf2.png)

### Serilog Logger Checking LogLevel

```c#
public void Interpolated_SerilogLogger_With_If_WithParams()
{
    if (_serilogLogger.IsEnabled(LogEventLevel.Information))
        _serilogLogger.Information($"This is a log message with parameters {464}, {4542}, {0}");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Interpolated_SerilogLogger_With_If_WithParams();
}
```

```shell
$ timeit ./Execute.InterpolatedTemplate.SerilogLogger.WithIf/bin/Release/net8.0/Execute.InterpolatedTemplate.SerilogLogger.WithIf 
150ms 964µs 681ns
```

![image-20241013203724213](./docs/InterpolatedTemplate.SerilogLogger.WithIf.png)

### Serilog Logger Not Checking LogLevel

```c#
public void Interpolated_SerilogLogger_Without_If_WithParams()
{
    _serilogLogger.Information($"This is a log message with parameters {464}, {4542}, {0}");
}

var compareEmptyLogsBenchmark = new CompareEmptyLogsBenchmark();
for (int i = 0; i < Constants.Iterations; i++)
{
    compareEmptyLogsBenchmark.Interpolated_SerilogLogger_Without_If_WithParams();
}
```

```shell
$ timeit ./Execute.InterpolatedTemplate.SerilogLogger.WithoutIf/bin/Release/net8.0/Execute.InterpolatedTemplate.SerilogLogger.WithoutIf 
321ms 544µs 137ns
```

![image-20241013203829605](./docs/InterpolatedTemplate.SerilogLogger.WithoutIf1.png)

![image-20241013204324269](./docs/InterpolatedTemplate.SerilogLogger.WithoutIf2.png)
