using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IProdutoApplication
    {
        public Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync();
        public Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync(Categoria nomeCategoria);
        public Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto);
    }
}
