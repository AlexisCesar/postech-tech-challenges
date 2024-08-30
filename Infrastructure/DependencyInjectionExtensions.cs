using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Application;
using ControleDePedidos.Infrastructure.Adapters;
using ControleDePedidos.Infrastructure.Data;
using ControleDePedidos.UseCases.Interfaces;
using ControleDePedidos.UseCases;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddScoped<IClienteUseCases, ClienteUseCases>();
            services.AddScoped<IClientePersistencePort, ClientePersistenceAdapter>();
            services.AddScoped<IProdutoUseCases, ProdutoUseCases>();
            services.AddScoped<IProdutoPersistencePort, ProdutoPersistenceAdapter>();
            services.AddScoped<IPedidoPersistencePort, PedidoPersistenceAdapter>();
            services.AddScoped<IAcompanhamentoUseCases, AcompanhamentoUseCases>();
            services.AddScoped<IBuscarPedidoUseCase, BuscarPedidoUseCase>();
            services.AddScoped<IClienteUseCases, ClienteUseCases>();
            services.AddScoped<IPagamentoUseCases, PagamentoUseCases>();
            services.AddScoped<IProdutoUseCases, ProdutoUseCases>();
            services.AddScoped<IRealizarPedidoUseCase, RealizarPedidoUseCase>();

            services.AddDbContext<ApplicationContext>();

            return services;
        }
    }
}