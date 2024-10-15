using ControleDePedidos.Core.Entities.ValueObjects;

namespace ControleDePedidos.Core.Entidades
{
    public class ClienteAggregate : Entity<Guid>, IAggregateRoot
    {
        public CPF? CPF { get; set; }
        public Email? Email { get; set; }
        public string? Nome { get; set; }
    }
}