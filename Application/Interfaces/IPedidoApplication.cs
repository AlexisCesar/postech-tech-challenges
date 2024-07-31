using ControleDePedidos.Application.Dtos;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IPedidoApplication
    {
        Task<short> RealizarPedido(PedidoDto pedidoDto);
    }
}
