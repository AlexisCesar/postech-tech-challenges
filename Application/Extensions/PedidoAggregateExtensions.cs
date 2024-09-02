using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Extensions
{
    static internal class PedidoAggregateExtensions
    {
        static internal PedidoDto ToPedidoDto(this PedidoAggregate pedidoAggregate)
        {
            var pedido =  new PedidoDto()
            {
                IdPedido = pedidoAggregate.Id,
                CpfCliente = pedidoAggregate.Cliente?.CPF?.ToString(),
                NomeCliente = pedidoAggregate.Cliente?.Nome,
                ValorTotal = pedidoAggregate.CalcularValorPedido(),
                StatusPedido = pedidoAggregate.Acompanhamento.Status.ToString(),
                CodigoAcompanhamento = pedidoAggregate.Acompanhamento.CodigoAcompanhamento,
                Pago = pedidoAggregate.Pagamento.Pago,
                IdPagamento = pedidoAggregate.Pagamento.Id,
                HorarioRecebimento = pedidoAggregate.HorarioRecebimento
            };

            pedidoAggregate.Itens.ForEach(i =>
            {
                pedido.Itens.Add(new ItemPedidoDto()
                {
                    Customizacao = i.Customizacao,
                    Quantidade = i.Quantidade,
                    IdProduto = i.Produto.Id,
                    Preco = i.Produto.Preco.Value
                });
 
            });

            return pedido;  
        }
    }
}
