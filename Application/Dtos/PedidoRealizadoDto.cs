namespace ControleDePedidos.Application.Dtos
{
    public class PedidoRealizadoDto
    {
        public Guid IdPedido { get; set; }
        public short CodigoAcompanhamento { get; set; }
        public Guid IdPagamento { get; set; }
    }
}