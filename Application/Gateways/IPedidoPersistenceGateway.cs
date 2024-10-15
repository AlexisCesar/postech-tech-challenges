using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;

namespace ControleDePedidos.Application.Gateways
{
    public interface IPedidoPersistenceGateway
    {
        Task<bool> SaveAcompanhamentoAsync(AcompanhamentoAggregate acompanhamento);
        Task<bool> SavePedidoAsync(PedidoAggregate pedido);
        Task <PedidoAggregate?> GetPedidoById (Guid idPedido);
        Task<List<PedidoAggregate>> GetAllPedidosNaoFinalizadosAsync();
        Task<List<PedidoAggregate>> GetAllPedidosByStatusAsync(Status status);
        Task<bool> SavePagamentoAsync(PagamentoAggregate pagamento);  
    }
}