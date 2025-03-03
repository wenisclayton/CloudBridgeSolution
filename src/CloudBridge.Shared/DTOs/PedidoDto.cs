using System.Text.Json.Serialization;

namespace CloudBridge.Shared.DTOs;

public record PedidoDto
{
    [JsonConstructor]
    public PedidoDto(string produto, int quantidade, decimal preco)
    {
        Produto = produto;
        Quantidade = quantidade;
        Preco = preco;
    }
    public string Produto { get; init; }
    public int Quantidade { get; init; }
    public decimal Preco { get; init; }
}
