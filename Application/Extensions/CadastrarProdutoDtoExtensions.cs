using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entidades;

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
                Preco = cadastraProdutoDto.Preco,
                Categoria = cadastraProdutoDto.Categoria,
            };
        }
    }
}
