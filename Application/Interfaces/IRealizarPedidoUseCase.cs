using ControleDePedidos.Application.Dtos;

namespace ControleDePedidos.UseCases.Interfaces
{
    public interface IRealizarPedidoUseCase
    {
        Task<PedidoRealizadoDto> RealizarPedido(CriaPedidoDto pedidoDto);
    }
}
