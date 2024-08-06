using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Dominio.Entidades
{
    public class AcompanhamentoAggregate : Entity<Guid>, IAggregateRoot
    {
        public short CodigoAcompanhamento { get; set; }
        public Status Status { get; set; }
    }
}
