using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;

namespace ControleDePedidos.Application
{
    public class ProdutoApplication : IProdutoApplication
    {

        private readonly IProdutoPersistencePort ProdutoPersistancePort;

        public ProdutoApplication(IProdutoPersistencePort produtoPersistancePort)
        {
            ProdutoPersistancePort = produtoPersistancePort;
        }

        public async Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto)
        {
            if (cadastraProdutoDto == null) throw new CadastrarProdutoException("Ocorreu um erro ao cadastrar o produto");

            var produtoAggregate = cadastraProdutoDto.ToProdutoAggregate();

            var produtoCadastrado = await ProdutoPersistancePort.SalvarProdutoAsync(produtoAggregate);

            if (!produtoCadastrado) throw new CadastrarProdutoException("Ocorreu um erro ao cadastrar o produto");
        }
    }
}
