﻿using ControleDePedidos.Core.Entities.ValueObjects;

namespace ControleDePedidos.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Categoria { get; set; } = "";
        public Preco Preco {  get; set; }
    }
}
