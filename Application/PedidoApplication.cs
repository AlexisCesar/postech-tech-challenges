using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application
{
    public class PedidoApplication : IPedidoApplication
    {
        private readonly IPedidoPersistencePort PedidoPersistencePort;
        private readonly IClientePersistencePort ClientePersistencePort;
        private readonly IProdutoPersistencePort ProdutoPersistencePort;

        public PedidoApplication(IPedidoPersistencePort pedidoPersistencePort,
                                    IClientePersistencePort clientePersistencePort,
                                    IProdutoPersistencePort produtoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
            ClientePersistencePort = clientePersistencePort;
            ProdutoPersistencePort = produtoPersistencePort;
        }

        public async Task<PedidoRealizadoDto> RealizarPedido(PedidoDto pedidoDto)
        {
            var cliente = await ClientePersistencePort.GetClienteByCPF(pedidoDto.CpfCliente ?? "");

            var produtos = await ProdutoPersistencePort.GetProdutosByIdsAsync(pedidoDto.Itens.Select(i => i.IdProduto));

            if(produtos.Count == 0 || produtos.Count != pedidoDto.Itens.Count)
            {
                throw new ProdutoNaoCadastradoException("Um ou mais produtos do pedido nao foram encontrados. Verifique o pedido.");
            }

            var pedido = pedidoDto.ToPedidoAggregate(cliente, produtos);

            var acompanhamento = new AcompanhamentoAggregate()
            {
                CodigoAcompanhamento = 999,
                Pedido = pedido,
                Status = Status.Recebido
            };

            var pagamento = new PagamentoAggregate()
            {
                Pedido = pedido
            };

            var pedidoCadastrado = await PedidoPersistencePort.SavePedidoAndAcompanhamentoAsync(pedido, acompanhamento, pagamento);

            if (!pedidoCadastrado) throw new RealizarPedidoException("Ocorreu um erro ao realizar o pedido.");

            return new PedidoRealizadoDto()
            {
                CodigoAcompanhamento = acompanhamento.CodigoAcompanhamento,
                UrlPagamento = "Mock URL de pagamaneto",
                IdPagamento = pagamento.Id
            };
        }

        public async Task ConfirmarPagamentoAsync(Guid idPagamento)
        {
            var pagamento = await PedidoPersistencePort.GetPagamentoByIdAsync(idPagamento);

            if (pagamento == null) throw new PagamentoNaoEncontradoException("Nao foi encontrado um pagamento com esse id.");

            var acompanhamento = await PedidoPersistencePort.GetAcompanhamentoByPedidoIdAsync(pagamento.Pedido.Id);

            if (acompanhamento == null) throw new AcompanhamentoNaoEncontradoException("Nao foi encontrado acompanhamento para esse pedido.");

            acompanhamento.Status = Status.Preparacao;

            var acompanhamentoAtualizado = await PedidoPersistencePort.SaveAcompanhamentoAsync(acompanhamento);

            if (!acompanhamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pedido.");
        }
    }
}
