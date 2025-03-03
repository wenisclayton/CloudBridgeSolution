using System.Text.Json.Serialization;
using CloudBridge.Shared.Configurations.Providers;

namespace CloudBridge.Shared.Configurations;

/// <summary>
/// Representa a configuração da aplicação, mapeando valores do appsettings.json.
/// </summary>
public record AppConfig
{
    [JsonPropertyName("AWS")]
    public AwsConfig AWS { get; init; }

    [JsonPropertyName("Azure")]
    public AzureConfig Azure { get; init; }

    [JsonPropertyName("GCP")]
    public GcpConfig GCP { get; init; }

    [JsonPropertyName("RabbitMQ")]
    public RabbitMqConfig RabbitMQ { get; init; }

    [JsonPropertyName("MessageQueue")]
    public MessageQueueDefaultSettings MessageQueue { get; init; }
}