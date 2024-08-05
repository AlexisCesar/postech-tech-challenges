using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IPedidoPersistencePort
    {
        Task<bool> SaveAcompanhamentoAsync(AcompanhamentoAggregate acompanhamento);
        Task<bool> SavePedidoAsync(PedidoAggregate pedido);
        Task <PedidoAggregate?> GetPedidoById (Guid idPedido);
        Task<List<PedidoAggregate>> GetAllPedidosNaoFinalizadosAsync();
        Task<List<PedidoAggregate>> GetAllPedidosRecebidosAsync();
        Task<List<PedidoAggregate>> GetAllPedidosEmPreparacaoAsync();
        Task<bool> SavePagamentoAsync(PagamentoAggregate pagamento);     
    }
}