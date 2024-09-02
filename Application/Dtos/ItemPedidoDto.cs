namespace ControleDePedidos.Application.Dtos
{
    public class ItemPedidoDto
    {
        public int IdProduto { get; set; }
        public short Quantidade { get; set; }
        public string? Customizacao { get; set; }
        public double Preco { get; set; }
    }
}