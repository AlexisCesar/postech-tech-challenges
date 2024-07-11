namespace ControleDePedidos.Dominio.Entidades
{
    public class PagamentoAggregate : Entity, IAggregateRoot
    {
        public PedidoAggregate Pedido { get; set; }
    }
}
