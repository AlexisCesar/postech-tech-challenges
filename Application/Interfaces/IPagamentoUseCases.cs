using ControleDePedidos.UseCases.Dtos;

namespace ControleDePedidos.UseCases.Interfaces
{
    public interface IPagamentoUseCases
    {
        Task ConfirmarPagamentoAsync(Guid idPedido);
        Task<PedidoQrCodeDTO> GerarQrCodeParaPagamento(Guid idPedido);
    }
}
