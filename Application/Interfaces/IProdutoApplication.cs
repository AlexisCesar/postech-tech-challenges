using ControleDePedidos.Application.Dtos;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IProdutoApplication
    {
        public Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync();
        public Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto);
    }
}
