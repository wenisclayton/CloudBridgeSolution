namespace CloudBridge.Shared.Configurations.Providers;

public record AzureConfig
{
    public string ServiceBusConnectionString { get; init; }
    public string QueueName { get; init; }
}