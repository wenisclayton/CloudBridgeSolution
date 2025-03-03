using System.Text.Json;
using CloudBridge.Messaging;
using CloudBridge.Shared.DTOs;
using CloudBridge.Shared.Enums;

namespace CloudBridge.API.Services;

public class PedidoService(MessageQueueServiceFactory queueFactory) : IPedidoService
{
    public async Task ProcessarPedidoAsync(ProviderEnum provider, PedidoDto? pedido)
    {
        var service = queueFactory.GetService(provider);
        var json = JsonSerializer.Serialize(pedido);
        await service.PublicarMensagemAsync(json);
    }
} 