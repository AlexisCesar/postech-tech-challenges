using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions.Pedido;
using ControleDePedidos.Application.Exceptions.Produto;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Gateways;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.UseCases.Interfaces;

namespace ControleDePedidos.UseCases
{
    public class RealizarPedidoUseCase : IRealizarPedidoUseCase
    {
        private readonly IPedidoPersistenceGateway PedidoPersistencePort;
        private readonly IClientePersistenceGateway ClientePersistencePort;
        private readonly IProdutoPersistenceGateway ProdutoPersistencePort;

        public RealizarPedidoUseCase(IPedidoPersistenceGateway pedidoPersistencePort,
                                    IClientePersistenceGateway clientePersistencePort,
                                    IProdutoPersistenceGateway produtoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
            ClientePersistencePort = clientePersistencePort;
            ProdutoPersistencePort = produtoPersistencePort;
        }

        public async Task<PedidoRealizadoDto> RealizarPedido(CriaPedidoDto pedidoDto)
        {
            var cliente = await ClientePersistencePort.GetClienteByCPF(pedidoDto.CpfCliente ?? "");

            var produtos = await ProdutoPersistencePort.GetProdutosByIdsAsync(pedidoDto.Itens.Select(i => i.IdProduto));

            if (produtos.Count == 0 || produtos.Count != pedidoDto.Itens.Count)
            {
                throw new ProdutoNaoCadastradoException("Um ou mais produtos do pedido nao foram encontrados. Verifique o pedido.");
            }
            var pedido = pedidoDto.ToPedidoAggregate(cliente, produtos);

            pedido.Acompanhamento = new AcompanhamentoAggregate()
            {
                Status = Status.Recebido
            };

            pedido.Pagamento = new PagamentoAggregate();

            var pedidoCadastrado = await PedidoPersistencePort.SavePedidoAsync(pedido);

            if (!pedidoCadastrado) throw new RealizarPedidoException("Ocorreu um erro ao realizar o pedido.");

            return new PedidoRealizadoDto()
            {
                IdPedido = pedido.Id,
                CodigoAcompanhamento = pedido.Acompanhamento.CodigoAcompanhamento,
                UrlPagamento = "Mock URL de pagamaneto",
                IdPagamento = pedido.Pagamento.Id
            };
        }
    }
}
