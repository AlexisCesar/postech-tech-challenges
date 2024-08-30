using ControleDePedidos.Application.Exceptions.Acompanhamento;
using ControleDePedidos.Application.Exceptions.Pagamento;
using ControleDePedidos.Application.Exceptions.Pedido;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.UseCases.Interfaces;

namespace ControleDePedidos.UseCases
{
    public class AcompanhamentoUseCases : IAcompanhamentoUseCases
    {
        private readonly IPedidoPersistencePort PedidoPersistencePort;

        public AcompanhamentoUseCases(IPedidoPersistencePort pedidoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
        }

        public async Task AtualizaStatusComoProntoAsync(Guid idPedido)
        {
            var pedido = await TryGetPedidoById(idPedido);

            if (pedido.Acompanhamento.Status != Status.Preparacao)
                throw new OperacaoInvalidaException("Status do pedido precisa estar em preparação para ser atualizado como pronto.");

            pedido.Acompanhamento.Status = Status.Pronto;

            await TryToSaveAcompanhamento(pedido);
        }

        public async Task FinalizaPedidoAsync(Guid idPedido)
        {
            var pedido = await TryGetPedidoById(idPedido);

            if (pedido.Acompanhamento.Status != Status.Pronto)
                throw new OperacaoInvalidaException("Status do pedido precisa estar como recebido para que o pedido possa ser finalizado.");

            pedido.Acompanhamento.Status = Status.Finalizado;

            await TryToSaveAcompanhamento(pedido);
        }

        private async Task<PedidoAggregate?> TryGetPedidoById(Guid idPedido)
        {
            var pedido = await PedidoPersistencePort.GetPedidoById(idPedido);

            if (pedido == null) throw new PedidoNaoEncontradoException("Pedido nao encontrado");

            if (pedido.Acompanhamento == null)
                throw new AcompanhamentoNaoEncontradoException("Nao foi encontrado acompanhamento para esse pedido.");

            return pedido;
        }
        private async Task TryToSaveAcompanhamento(PedidoAggregate? pedido)
        {
            var acompanhamentoAtualizado = await PedidoPersistencePort.SaveAcompanhamentoAsync(pedido.Acompanhamento);

            if (!acompanhamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pedido.");
        }
    }
}
