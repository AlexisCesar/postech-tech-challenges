using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entidades;

namespace ControleDePedidos.Application.Ports
{
    public interface IProdutoPersistencePort
    {
        public Task<bool> SalvarProdutoAsync(ProdutoAggregate produtoAggregate);
    }
}
