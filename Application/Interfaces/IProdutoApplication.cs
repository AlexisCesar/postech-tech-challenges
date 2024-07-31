using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application.Interfaces
{
    public interface IProdutoApplication
    {
        Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync();
        Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync(Categoria nomeCategoria);
        Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto);
        Task RemoveProdutoAsync(Guid id);
    }
}
