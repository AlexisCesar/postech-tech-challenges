using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entities.Enums;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IProdutoApplication
    {
        Task<ProdutoDto> AtualizaProdutoAsync(int id, AtualizaProdutoDto produto);
        Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync();
        Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync(Categoria nomeCategoria);
        Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto);
        Task RemoveProdutoAsync(int id);
    }
}
