using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IPedidoPersistencePort
    {
        Task<AcompanhamentoAggregate?> GetAcompanhamentoByPedidoIdAsync(Guid idPedido);
        Task<PagamentoAggregate?> GetPagamentoByIdAsync(Guid idPagamento);
        Task<bool> SaveAcompanhamentoAsync(AcompanhamentoAggregate acompanhamento);
        Task<bool> SavePedidoAndAcompanhamentoAsync(PedidoAggregate pedido, AcompanhamentoAggregate acompanhamento, PagamentoAggregate pagamento);
        Task <PedidoAggregate?> GetPedidoById (Guid idPedido);
    }
}