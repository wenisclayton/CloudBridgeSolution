namespace CloudBridge.Shared.Configurations;

public record MessageQueueDefaultSettings
{
    public string DefaultProvider { get; init; } // AWS, Azure, GCP ou RabbitMQ
}