﻿using ControleDePedidos.Core.Entidades;
using ControleDePedidos.Core.Entities.Enums;

namespace ControleDePedidos.Application.Gateways
{
    public interface IProdutoPersistenceGateway
    {
        public Task<bool> SaveProdutoAsync(ProdutoAggregate produtoAggregate);
        Task<ProdutoAggregate?> GetProdutoByNomeAsync(string nome);
        Task<ProdutoAggregate?> GetProdutoByIdAsync(int id);
        Task<IEnumerable<ProdutoAggregate>> GetProdutosAsync();
        Task<IEnumerable<ProdutoAggregate>> GetProdutosByCategoriaAsync(Categoria categoria);
        bool RemoveProduto(ProdutoAggregate produtoAggregate);
        Task<bool> UpdateProdutoAsync(ProdutoAggregate produtoCadastrado);
        Task<List<ProdutoAggregate>> GetProdutosByIdsAsync(IEnumerable<int> ids);
    }
}
