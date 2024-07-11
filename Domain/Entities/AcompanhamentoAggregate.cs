using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Dominio.Entidades
{
    public class AcompanhamentoAggregate : Entity, IAggregateRoot
    {
        public short CodigoAcompanhamento { get; set; }
        public PedidoAggregate Pedido { get; set; }
        public Status Status { get; set; }
    }
}
