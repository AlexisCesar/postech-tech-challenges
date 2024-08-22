using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.ValueObjects;

namespace ControleDePedidos.Application.Extensions
{
    static internal class CadastrarProdutoDtoExtensions 
    {
        static internal ProdutoAggregate ToProdutoAggregate(this CadastraProdutoDto cadastraProdutoDto)
        {
            if(cadastraProdutoDto == null)
            {
                return new ProdutoAggregate();
            }

            return new ProdutoAggregate()
            {
                Nome = cadastraProdutoDto.Nome,
                Preco = new Preco(cadastraProdutoDto.Preco),
                Categoria = cadastraProdutoDto.Categoria,
            };
        }
    }
}
