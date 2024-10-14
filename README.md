# Standalone Applications Memory Profiling

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



![image-20241013203829605](./docs/InterpolatedTemplate.SerilogLogger.WithoutIf1.png)

![image-20241013204324269](./docs/InterpolatedTemplate.SerilogLogger.WithoutIf2.png)
