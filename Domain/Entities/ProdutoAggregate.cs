using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.Core.Entities.ValueObjects;

namespace ControleDePedidos.Core.Entidades
{
    public class ProdutoAggregate : Entity<int>, IAggregateRoot
    {
        public string Nome { get; set; }
        public Preco Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}
