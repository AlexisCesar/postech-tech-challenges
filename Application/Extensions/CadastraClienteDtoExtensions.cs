using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Dominio.Entidades;
using ControleDePedidos.Dominio.Entities.ValueObjects;

namespace ControleDePedidos.Application.Extensions
{
    static internal class CadastraClienteDtoExtensions
    {
        static internal ClienteAggregate ToClienteAggregate(this CadastraClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                return new ClienteAggregate();
            }

            return new ClienteAggregate()
            {
                CPF = clienteDto.CPF,
                Email = new Email()
                {
                    Endereco = clienteDto.EnderecoEmail ?? ""
                },
                Nome = clienteDto.Nome
            };
        }
    }
}
