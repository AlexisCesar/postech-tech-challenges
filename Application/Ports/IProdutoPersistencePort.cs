using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application.Ports
{
    public interface IProdutoPersistencePort
    {
        public Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate);
        Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome);
        Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync();
        Task<IEnumerable<ProdutoAggregate>> GetProdutosByCategoriaAsync(Categoria categoria);
    }
}
