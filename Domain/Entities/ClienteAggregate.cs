﻿using ControleDePedidos.Dominio.Entities.ValueObjects;

namespace ControleDePedidos.Dominio.Entidades
{
    public class ClienteAggregate : Entity<Guid>, IAggregateRoot
    {
        public string? CPF { get; set; }
        public Email? Email { get; set; }
        public string? Nome { get; set; }
    }
}