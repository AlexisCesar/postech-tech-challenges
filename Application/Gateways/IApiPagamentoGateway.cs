using ControleDePedidos.Core.Entidades;

namespace ControleDePedidos.UseCases.Gateways
{
    public interface IApiPagamentoGateway
    {
        Task<string> GerarQrCodeParaPagamentoAsync(PedidoAggregate pedido);
    }
}
