using ControleDePedidos.Application.Exceptions.Acompanhamento;
using ControleDePedidos.Application.Exceptions.Pagamento;
using ControleDePedidos.Application.Exceptions.Pedido;
using ControleDePedidos.Application.Gateways;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.UseCases.Dtos;
using ControleDePedidos.UseCases.Gateways;
using ControleDePedidos.UseCases.Interfaces;

namespace ControleDePedidos.UseCases
{
    public class PagamentoUseCases : IPagamentoUseCases
    {
        private readonly IPedidoPersistenceGateway PedidoPersistenceGateway;
        private readonly IApiPagamentoGateway ApiPagamentoGateway;

        public PagamentoUseCases(IPedidoPersistenceGateway pedidoPersistencePort, IApiPagamentoGateway apiPagamentoGateway)
        {
            PedidoPersistenceGateway = pedidoPersistencePort;
            ApiPagamentoGateway = apiPagamentoGateway;
        }

        public async Task ConfirmarPagamentoAsync(Guid idPedido)
        {
            var pedido = await TryGetPedidoById(idPedido);

            pedido.Acompanhamento.Status = Status.Preparacao;
            pedido.Pagamento.Pago = true;

            var pagamentoAtualizado = await PedidoPersistenceGateway.SavePagamentoAsync(pedido.Pagamento);

            if (!pagamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pagamento.");

            await TryToSaveAcompanhamento(pedido);
        }

        public async Task<PedidoQrCodeDTO> GerarQrCodeParaPagamento(Guid idPedido)
        {
            var pedido = await TryGetPedidoById(idPedido);

            var dadosQrCode = await ApiPagamentoGateway.GerarQrCodeParaPagamentoAsync(pedido!);

            return new PedidoQrCodeDTO()
            {
                IdPedido = idPedido,
                DadosQrCode = dadosQrCode
            };
        }

        private async Task<PedidoAggregate?> TryGetPedidoById(Guid idPedido)
        {
            var pedido = await PedidoPersistenceGateway.GetPedidoById(idPedido);

            if (pedido == null) throw new PedidoNaoEncontradoException("Pedido nao encontrado");

            if (pedido.Acompanhamento == null)
                throw new AcompanhamentoNaoEncontradoException("Nao foi encontrado acompanhamento para esse pedido.");

            return pedido;
        }

        private async Task TryToSaveAcompanhamento(PedidoAggregate? pedido)
        {
            var acompanhamentoAtualizado = await PedidoPersistenceGateway.SaveAcompanhamentoAsync(pedido.Acompanhamento);

            if (!acompanhamentoAtualizado) throw new ConfirmarPagamentoException("Nao foi possivel atualizar o status do pedido.");
        }
    }
}
