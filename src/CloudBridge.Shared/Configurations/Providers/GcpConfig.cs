namespace CloudBridge.Shared.Configurations.Providers;

public record GcpConfig
{
    public string ProjectId { get; init; }
    public string TopicId { get; init; }
    public string SubscriptionId { get; init; }
}