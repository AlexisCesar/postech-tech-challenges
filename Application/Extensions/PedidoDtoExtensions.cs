using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.Application.Extensions
{
    static internal class PedidoDtoExtensions
    {
        static internal PedidoAggregate ToPedidoAggregate(this CriaPedidoDto pedidoDto, ClienteAggregate? cliente, List<ProdutoAggregate> produtos)
        {
            if (pedidoDto == null)
            {
                return new PedidoAggregate();
            }

            var pedido = new PedidoAggregate()
            {
                Cliente = cliente
            };

            pedidoDto.Itens.ForEach(i =>
            {
                pedido.Itens.Add(new ItemPedido()
                {
                    Quantidade = i.Quantidade,
                    Customizacao = i.Customizacao,
                    Produto = produtos.First(p => p.Id == i.IdProduto)
                });
            });

            return pedido;
        }
    }
}
