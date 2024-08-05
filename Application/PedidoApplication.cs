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

        public async Task<PedidoRealizadoDto> RealizarPedido(CriaPedidoDto pedidoDto)
        {
            var cliente = await ClientePersistencePort.GetClienteByCPF(pedidoDto.CpfCliente ?? "");

            var produtos = await ProdutoPersistencePort.GetProdutosByIdsAsync(pedidoDto.Itens.Select(i => i.IdProduto));

            if(produtos.Count == 0 || produtos.Count != pedidoDto.Itens.Count)
            {
                throw new ProdutoNaoCadastradoException("Um ou mais produtos do pedido nao foram encontrados. Verifique o pedido.");
            }

            var pedido = pedidoDto.ToPedidoAggregate(cliente, produtos);

            pedido.Acompanhamento = new AcompanhamentoAggregate()
            {
                CodigoAcompanhamento = 999,
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

        public async Task ConfirmarPagamentoAsync(Guid idPedido)
        {
            var pedido = await PedidoPersistencePort.GetPedidoById(idPedido);

            if (pedido == null) throw new PedidoNaoEncontradoException("Pedido nao encontrado.");

            if (pedido.Pagamento == null) throw new PagamentoNaoEncontradoException("Nao foi encontrado um pagamento para este pedido.");

            pedido.Acompanhamento.Status = Status.Preparacao;
            pedido.Pagamento.Pago = true;

            var pagamentoAtualizado = await PedidoPersistencePort.SavePagamentoAsync(pedido.Pagamento);

            if (!pagamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pagamento.");

            var acompanhamentoAtualizado = await PedidoPersistencePort.SaveAcompanhamentoAsync(pedido.Acompanhamento);

            if (!acompanhamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pedido.");
        }

        public async Task AtualizaStatusComoProntoAsync(Guid idPedido)
        {
            var pedido = await PedidoPersistencePort.GetPedidoById(idPedido);

            if (pedido == null) throw new PedidoNaoEncontradoException("Pedido nao encontrado");

            if (pedido.Acompanhamento == null) 
                throw new AcompanhamentoNaoEncontradoException("Nao foi encontrado acompanhamento para esse pedido.");

            if(pedido.Acompanhamento.Status != Status.Preparacao) 
                throw new OperacaoInvalidaException("Status do pedido precisa estar em preparação para ser atualizado como pronto.");

            pedido.Acompanhamento.Status = Status.Pronto;

            var acompanhamentoAtualizado = await PedidoPersistencePort.SaveAcompanhamentoAsync(pedido.Acompanhamento);

            if (!acompanhamentoAtualizado) throw new AtualizarStatusException("Nao foi possivel atualizar o status do pedido.");

        }

        public async Task FinalizaPedidoAsync(Guid idPedido)
        {
            var pedido = await PedidoPersistencePort.GetPedidoById(idPedido);

            if (pedido == null)
                throw new PedidoNaoEncontradoException("Pedido nao encontrado");

            if (pedido.Acompanhamento == null) 
                throw new AcompanhamentoNaoEncontradoException("Nao foi encontrado acompanhamento para esse pedido.");

            if (pedido.Acompanhamento.Status != Status.Pronto) 
                throw new OperacaoInvalidaException("Status do pedido precisa estar como recebido para que o pedido possa ser finalizado.");

            pedido.Acompanhamento.Status = Status.Finalizado;

            var acompanhamentoAtualizado = await PedidoPersistencePort.SaveAcompanhamentoAsync(pedido.Acompanhamento);

            if (!acompanhamentoAtualizado) throw new AtualizarStatusException("Nao foi possivel atualizar o status do pedido.");
        }

        public async Task<List<PedidoDto>> GetAllPedidosAsync()
        {
            var pedidos = await PedidoPersistencePort.GetAllPedidosNaoFinalizadosAsync();
            var pedidosDto = pedidos.Select(x => x.ToPedidoDto()).ToList();          

            return pedidosDto;
        }

        public async Task<List<PedidoDto>> GetAllPedidosWithStatusRecebidoAsync()
        {
            var acompanhamentos = await PedidoPersistencePort.GetAllPedidosRecebidosAsync();
            var acompanhamentosDto = acompanhamentos.Select(x => x.ToPedidoDto()).ToList();

            return acompanhamentosDto;
        }

        public async Task<List<PedidoDto>> GetAllPedidosWithStatusEmPreparacaoAsync()
        {
            var acompanhamentos = await PedidoPersistencePort.GetAllPedidosEmPreparacaoAsync();
            var acompanhamentosDto = acompanhamentos.Select(x => x.ToPedidoDto()).ToList();

            return acompanhamentosDto;
        }
    }
}
