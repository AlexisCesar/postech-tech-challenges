namespace ControleDePedidos.Dominio.Entidades
{
    public class PedidoAggregate : Entity, IAggregateRoot
    {
        public ClienteAggregate? Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

        public double CalcularValorPedido () => Itens.Sum(x => x.Produto.Preco);
    }
}