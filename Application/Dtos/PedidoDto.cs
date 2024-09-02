namespace ControleDePedidos.Application.Dtos
{
    public class PedidoDto
    {
        public Guid IdPedido { get; set; }
        public Guid IdPagamento { get; set; }
        public bool Pago { get; set; } 
        public string? CpfCliente { get; set; }
        public string? NomeCliente { get; set; }
        public string? StatusPedido { get; set; }
        public short CodigoAcompanhamento { get; set; }       
        public double ValorTotal { get; set; }
        public List<ItemPedidoDto> Itens { get; set; } = new List<ItemPedidoDto>();
        public DateTime HorarioRecebimento { get; set; }
    }
}
