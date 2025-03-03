using CloudBridge.Shared.DTOs;
using CloudBridge.API.Services;
using CloudBridge.Shared.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CloudBridge.API.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidoController(IPedidoService pedidoService) : ControllerBase
{
    /// <summary>
    /// Envia um pedido para um provedor de mensageria específico.
    /// </summary>
    /// <param name="provider">O provedor de mensageria (AWS, Azure, GCP, RabbitMQ).</param>
    /// <param name="pedido">Os dados do pedido.</param>
    /// <returns>Retorna o status do envio do pedido.</returns>
    [HttpPost("{provider}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CriarPedido(
        [FromRoute] ProviderEnum provider,
        [FromBody] PedidoDto? pedido)
    {
        if (pedido is null)
        {
            return BadRequest(new { error = "O corpo da requisição não pode ser nulo." });
        }

        if (!Enum.IsDefined(provider))
        {
            var allowedProviders = string.Join(", ", Enum.GetNames(typeof(ProviderEnum)));
            return BadRequest(new { error = $"Provedor inválido. Valores permitidos: {allowedProviders}" });
        }

        try
        {
            await pedidoService.ProcessarPedidoAsync(provider, pedido);
            return Accepted(new { message = $"Pedido enviado para {provider} com sucesso." });
        }
        catch (ArgumentException)
        {
            return NotFound(new { error = $"Provedor '{provider}' não encontrado." });
        }
    }
}