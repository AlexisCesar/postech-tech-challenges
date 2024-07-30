using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class ProdutoPersistenceAdapter : IProdutoPersistencePort
    {
        private ApplicationContext Context;

        public ProdutoPersistenceAdapter(ApplicationContext context)
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
    }
}
