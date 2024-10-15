namespace ControleDePedidos.Core.Entidades
{
    public class PagamentoAggregate : Entity<Guid>, IAggregateRoot
    {
        public bool Pago { get; set; } = false;
    }
}
