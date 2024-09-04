using ControleDePedidos.Application.Gateways;
using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Gateways
{
    internal class ProdutoPersistenceGateway : IProdutoPersistenceGateway
    {
        private ApplicationContext Context;

        public ProdutoPersistenceGateway(ApplicationContext context)
        {
            Context = context;
        }

        public async Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate)
        {
            await Context.Produto.AddAsync(produtoAggregate);
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome)
        {
            return await Context.Produto.FirstOrDefaultAsync(p => p.Nome == nome);
        }

        public async Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync()
        {
            return await Context.Produto.ToListAsync();
        }

        public async Task<IEnumerable<ProdutoAggregate>> GetProdutosByCategoriaAsync(Categoria categoria)
        {
            return await Context.Produto.Where(x => x.Categoria == categoria).ToListAsync();
        }

        public async Task<ProdutoAggregate?> GetProdutoByIdAsync(int id)
        {
            return await Context.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool RemoveProduto(ProdutoAggregate produto)
        {
            Context.Produto.Remove(produto);
            return Context.SaveChanges() > 0;
        }

        public async Task<bool> UpdateProdutoAsync(ProdutoAggregate produtoCadastrado)
        {
            Context.Produto.Update(produtoCadastrado);
            return await Context.SaveChangesAsync() > 0;
        }

        public async Task<List<ProdutoAggregate>> GetProdutosByIdsAsync(IEnumerable<int> ids)
        {
            return await Context.Produto.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
