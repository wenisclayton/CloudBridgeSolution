using CloudBridge.Shared.Configurations;
using Google.Cloud.PubSub.V1;
using Google.Protobuf;
using Microsoft.Extensions.Options;

namespace CloudBridge.Messaging.Providers;

public class GcpPubSubService : IMessageQueueService
{
    private readonly PublisherClient _publisher;
    private readonly string _topicId;

    public GcpPubSubService(IOptions<AppConfig> config)
    {
        _topicId = config.Value.GCP.TopicId;
        _publisher = PublisherClient.Create(TopicName.FromProjectTopic(config.Value.GCP.ProjectId, _topicId));
    }

    public async Task PublicarMensagemAsync(string mensagem)
    {
        var pubsubMessage = new PubsubMessage
        {
            Data = ByteString.CopyFromUtf8(mensagem)
        };

        await _publisher.PublishAsync(pubsubMessage);
    }
}
