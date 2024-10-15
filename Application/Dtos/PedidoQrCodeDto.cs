namespace ControleDePedidos.UseCases.Dtos
{
    public class PedidoQrCodeDTO
    {
        public Guid IdPedido { get; set; }
        public string DadosQrCode { get; set; }
    }
}
