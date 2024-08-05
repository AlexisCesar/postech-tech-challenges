using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entities.Enums;

namespace ControleDePedidos.Application
{
    public class ProdutoApplication : IProdutoApplication
    {

        private readonly IProdutoPersistencePort ProdutoPersistancePort;

        public ProdutoApplication(IProdutoPersistencePort produtoPersistancePort)
        {
            ProdutoPersistancePort = produtoPersistancePort;
        }

        public async Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync()
        {
            var produtos = await ProdutoPersistancePort.GetProdutosAsync();

            return produtos.Select(x => x.ToProdutoDto());
        }

        public async Task<IEnumerable<ProdutoDto>> BuscaProdutosAsync(Categoria categoria)
        {
            var produtos = await ProdutoPersistancePort.GetProdutosByCategoriaAsync(categoria);
            return produtos.Select(x => x.ToProdutoDto());
        }

        public async Task CadastraProdutoAsync(CadastraProdutoDto cadastraProdutoDto)
        {
            if (cadastraProdutoDto == null) throw new CadastrarProdutoException("Ocorreu um erro ao cadastrar o produto");

            if (await VerificarProdutoJaCadastrado(cadastraProdutoDto.Nome!)) throw new ProdutoJaCadastradoException("Produto ja cadastrado.");

            var produtoAggregate = cadastraProdutoDto.ToProdutoAggregate();

            var produtoCadastrado = await ProdutoPersistancePort.SaveProdutoAsync(produtoAggregate);

            if (!produtoCadastrado) throw new CadastrarProdutoException("Ocorreu um erro ao cadastrar o produto");
        }

        public async Task RemoveProdutoAsync(int id)
        {
            var produtoCadastrado = await ProdutoPersistancePort.GetProdutoByIdAsync(id);

            if (produtoCadastrado == null) throw new ProdutoNaoCadastradoException("Produto nao encontrado.");

            var produtoRemovido = ProdutoPersistancePort.RemoveProduto(produtoCadastrado);

            if (!produtoRemovido) throw new RemoveProdutoException("Ocorreu um erro ao remover o produto.");
        }

        private async Task<bool> VerificarProdutoJaCadastrado(string nome)
        {
            var produto = await ProdutoPersistancePort.GetProdutoByNomeAsync(nome);

            return produto != null;
        }

        public async Task<ProdutoDto> AtualizaProdutoAsync(int id, AtualizaProdutoDto produto)
        {
            var produtoCadastrado = await ProdutoPersistancePort.GetProdutoByIdAsync(id);

            if (produtoCadastrado == null) throw new ProdutoNaoCadastradoException("Produto nao encontrado.");

            produtoCadastrado.Nome = produto.Nome;
            produtoCadastrado.Preco = produto.Preco;
            produtoCadastrado.Categoria = produto.Categoria;

            var produtoAtualizado = await ProdutoPersistancePort.UpdateProdutoAsync(produtoCadastrado);

            if (!produtoAtualizado) throw new AtualizaProdutoException("Ocorreu um erro ao atualizar o produto.");

            return produtoCadastrado.ToProdutoDto();
        }
    }
}
