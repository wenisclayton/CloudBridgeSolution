using CloudBridge.Shared.DTOs;
using CloudBridge.Shared.Enums;

namespace CloudBridge.API.Services;

using System.Threading.Tasks;

public interface IPedidoService
{
    /// <summary>
    /// Processa um pedido enviando-o para o provedor de mensageria especificado.
    /// </summary>
    /// <param name="provider">Nome do provedor (AWS, Azure, GCP, RabbitMQ).</param>
    /// <param name="pedido">Objeto do pedido a ser processado.</param>
    Task ProcessarPedidoAsync(ProviderEnum provider, PedidoDto? pedido);
}
