using ControleDePedidos.Dominio.ValueObjects;

namespace ControleDePedidos.Dominio.Entidades
{
    public class ClienteAggregate : Entity, IAggregateRoot
    {
        public string? CPF { get; set; }
        public Email? Email { get; set; }
        public string? Nome { get; set; }
    }
}