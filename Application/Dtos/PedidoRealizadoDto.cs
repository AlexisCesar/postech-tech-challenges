namespace ControleDePedidos.Application.Dtos
{
    public class PedidoRealizadoDto
    {
        public short CodigoAcompanhamento { get; set; }
        public string UrlPagamento { get; set; }
        public Guid IdPagamento { get; set; }
    }
}