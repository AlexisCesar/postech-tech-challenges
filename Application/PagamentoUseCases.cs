using ControleDePedidos.Application.Exceptions.Acompanhamento;
using ControleDePedidos.Application.Exceptions.Pagamento;
using ControleDePedidos.Application.Exceptions.Pedido;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.UseCases.Interfaces;

namespace ControleDePedidos.UseCases
{
    public class PagamentoUseCases : IPagamentoUseCases
    {
        private readonly IPedidoPersistencePort PedidoPersistencePort;

        public PagamentoUseCases(IPedidoPersistencePort pedidoPersistencePort)
        {
            PedidoPersistencePort = pedidoPersistencePort;
        }

        public async Task ConfirmarPagamentoAsync(Guid idPedido)
        {
            var pedido = await TryGetPedidoById(idPedido);

            pedido.Acompanhamento.Status = Status.Preparacao;
            pedido.Pagamento.Pago = true;

            var pagamentoAtualizado = await PedidoPersistencePort.SavePagamentoAsync(pedido.Pagamento);

            if (!pagamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pagamento.");

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
