using ControleDePedidos.Application.Ports;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Infrastructure.Data;

namespace ControleDePedidos.Infrastructure.Adapters
{
    public class ProdutoPersistenceAdapter : IProdutoPersistencePort
    {
        private ApplicationContext Context;

        public ProdutoPersistenceAdapter(ApplicationContext context)
        {
            Context = context;
        }
        public async Task<bool> SalvarProdutoAsync(ProdutoAggregate produtoAggregate)
        {
            await Context.Produto.AddAsync(produtoAggregate);
            var result = await Context.SaveChangesAsync();
            return result > 0;
        }
    }
}
