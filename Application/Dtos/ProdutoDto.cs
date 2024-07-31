namespace ControleDePedidos.Application.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double Preco {  get; set; }
    }
}
