using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IProdutoPersistencePort
    {
        public Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate);
        Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome);
        Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync();
    }
}
