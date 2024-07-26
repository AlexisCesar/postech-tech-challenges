using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Dominio.Entidades
{
    public class ProdutoAggregate : Entity, IAggregateRoot
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public Categoria Categoria { get; set; }
    }
}
