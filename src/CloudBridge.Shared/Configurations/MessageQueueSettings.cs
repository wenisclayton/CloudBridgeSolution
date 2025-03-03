namespace CloudBridge.Shared.Configurations;

public record MessageQueueSettings(
    string AwsQueueUrl,
    string AzureConnectionString,
    string GcpProjectId,
    string RabbitMqHostName
);
