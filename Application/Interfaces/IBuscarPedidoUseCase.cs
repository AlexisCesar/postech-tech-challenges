using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entities.Enums;

namespace ControleDePedidos.UseCases.Interfaces
{
    public interface IBuscarPedidoUseCase
    {
        Task<List<PedidoDto>> GetAllPedidosAsync();
        Task<List<PedidoDto>> GetAllPedidosByStatusAsync(Status status);
    }
}
