using Azure.Messaging.ServiceBus;
using CloudBridge.Shared.Configurations;
using Microsoft.Extensions.Options;

namespace CloudBridge.Messaging.Providers;

public class AzureServiceBusService(IOptions<AppConfig> config) : IMessageQueueService
{
    private readonly ServiceBusClient _client = new(config.Value.Azure.ServiceBusConnectionString);
    private readonly string _queueName = config.Value.Azure.QueueName;

    public async Task PublicarMensagemAsync(string mensagem)
    {
        if (string.IsNullOrWhiteSpace(mensagem))
        {
            throw new ArgumentException("A mensagem não pode ser vazia.");
        }
        
        var sender = _client.CreateSender(_queueName);
        var message = new ServiceBusMessage(mensagem);
        await sender.SendMessageAsync(message);
    }
}
