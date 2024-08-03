using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Extensions
{
    static internal class AcompanhamentoAggregateExtensions
    {
        static internal PedidoDto ToPedidoDto(this AcompanhamentoAggregate acompanhamento)
        {
            var pedido =  new PedidoDto()
            {
                CpfCliente = acompanhamento.Pedido.Cliente?.CPF,
                NomeCliente = acompanhamento.Pedido.Cliente?.Nome,
                StatusPedido = acompanhamento.Status.ToString(),
                CodigoAcompanhamento = acompanhamento.CodigoAcompanhamento,
                ValorTotal = acompanhamento.Pedido.CalcularValorPedido(),
                IdPedido = acompanhamento.Id,
            };

            acompanhamento.Pedido.Itens.ForEach(i =>
            {
                pedido.Itens.Add(new ItemPedidoDto()
                {
                    Customizacao = i.Customizacao,
                    Quantidade = i.Quantidade,
                    IdProduto = i.Id
                });
 
            });

            return pedido;  
        }
    }
}
