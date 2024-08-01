using ControleDePedidos.Application.Dtos;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IPedidoApplication
    {
        Task ConfirmarPagamentoAsync(Guid idPagamento);
        Task<PedidoRealizadoDto> RealizarPedido(PedidoDto pedidoDto);
    }
}
