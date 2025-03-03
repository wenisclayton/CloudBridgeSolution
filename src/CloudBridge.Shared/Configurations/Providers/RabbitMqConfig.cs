namespace CloudBridge.Shared.Configurations.Providers;

public record RabbitMqConfig
{
    public string Host { get; init; }
    public int Port { get; init; }
    public string Username { get; init; }
    public string Password { get; init; }
    public string QueueName { get; init; }
}