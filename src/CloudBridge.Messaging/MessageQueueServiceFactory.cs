using CloudBridge.Messaging.Providers;
using CloudBridge.Shared.Enums;
using Microsoft.Extensions.DependencyInjection;

namespace CloudBridge.Messaging;
using System;

public class MessageQueueServiceFactory
{
    private readonly IServiceProvider _serviceProvider;

    public MessageQueueServiceFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IMessageQueueService GetService(ProviderEnum provider)
    {
        return provider switch
        {
            ProviderEnum.AWS => _serviceProvider.GetRequiredService<AwsSqsService>(),
            ProviderEnum.Azure => _serviceProvider.GetRequiredService<AzureServiceBusService>(),
            ProviderEnum.GCP => _serviceProvider.GetRequiredService<GcpPubSubService>(),
            ProviderEnum.RabbitMQ => _serviceProvider.GetRequiredService<RabbitMqService>(),
            _ => throw new ArgumentException("Provedor de mensageria não suportado.")
        };
    }
}
