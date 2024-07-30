using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Extensions
{
    static internal class ProdutoAggregateExtensions
    {
        static internal ProdutoDto ToProdutoDto(this ProdutoAggregate produtoAggregate)
        {
            if (produtoAggregate == null)
            {
                return new ProdutoDto();
            }

            return new ProdutoDto()
            {
                Nome = produtoAggregate.Nome,
                Preco = produtoAggregate.Preco,
                Categoria = produtoAggregate.Categoria.ToString(),
            };
        }
    }
}
