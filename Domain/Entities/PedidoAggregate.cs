﻿namespace ControleDePedidos.Core.Entidades
{
    public class PedidoAggregate : Entity<Guid>, IAggregateRoot
    {
        public ClienteAggregate? Cliente { get; set; }
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        public double CalcularValorPedido () => Itens.Sum(x => x.Produto.Preco.Value * x.Quantidade);
        public PagamentoAggregate Pagamento {  get; set; }
        public AcompanhamentoAggregate Acompanhamento { get; set; }
        public DateTime HorarioRecebimento { get; set; } = DateTime.UtcNow;
    }
}