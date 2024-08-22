using ControleDePedidos.Core.Entities.Enums;

namespace ControleDePedidos.Core.Entidades
{
    public class AcompanhamentoAggregate : Entity<Guid>, IAggregateRoot
    {
        public short CodigoAcompanhamento { get; set; }
        public Status Status { get; set; }
    }
}
