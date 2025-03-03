using Serilog;

namespace CloudBridge.API.Logging;

public static class LoggingExtensions
{
    public static IHostBuilder UseCustomSerilog(this IHostBuilder hostBuilder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        hostBuilder.UseSerilog();
        return hostBuilder;
    }
}
