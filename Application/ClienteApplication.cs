using ControleDePedidos.Application.Dtos;
using ControleDePedidos.Application.Exceptions;
using ControleDePedidos.Application.Extensions;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;

namespace ControleDePedidos.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IClientePersistancePort ClientePersistancePort;

        public ClienteApplication(IClientePersistancePort clientePersistancePort)
        {
            ClientePersistancePort = clientePersistancePort;
        }

        public async Task CadastraClienteAsync(CadastraClienteDto clienteDto)
        {
            var clienteAggregate = clienteDto.ToClienteAggregate();
            
            var clienteCadastrado = await ClientePersistancePort.SalvarClienteAsync(clienteAggregate);

            if(!clienteCadastrado) throw new CadastrarClienteException("Ocorreu um erro ao cadastrar o cliente.");
        }
    }
}
