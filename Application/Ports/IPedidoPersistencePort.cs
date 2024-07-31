using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IPedidoPersistencePort
    {
        Task<bool> SavePedidoAndAcompanhamentoAsync(PedidoAggregate pedido, AcompanhamentoAggregate acompanhamento);
    }
}