using ControleDePedidos.Application.Dtos;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IPedidoApplication
    {
        Task AtualizaStatusComoProntoAsync(Guid idPedido);
        Task ConfirmarPagamentoAsync(Guid idPedido);
        Task<PedidoRealizadoDto> RealizarPedido(CriaPedidoDto pedidoDto);
        Task FinalizaPedidoAsync(Guid idPedido);
        Task<List<PedidoDto>> GetAllPedidosAsync();
        Task<List<PedidoDto>> GetAllPedidosWithStatusRecebidoAsync();
        Task<List<PedidoDto>> GetAllPedidosWithStatusEmPreparacaoAsync();
    }
}
