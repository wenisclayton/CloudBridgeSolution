namespace CloudBridge.Shared.Configurations.Providers;

public record AwsConfig
{
    public string Region { get; init; }
    public string SQSQueueUrl { get; init; }
    public string AccessKey { get; init; }
    public string SecretKey { get; init; }
}