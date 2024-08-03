namespace ControleDePedidos.Dominio.Entidades
{
    public class PagamentoAggregate : Entity, IAggregateRoot
    {
        public PedidoAggregate Pedido { get; set; }
        public bool Pago { get; set; } = false;
    }
}
