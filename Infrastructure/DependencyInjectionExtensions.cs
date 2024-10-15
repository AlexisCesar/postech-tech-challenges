using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Gateways;
using ControleDePedidos.Application;
using ControleDePedidos.Infrastructure.Gateways;
using ControleDePedidos.Infrastructure.Data;
using ControleDePedidos.UseCases.Interfaces;
using ControleDePedidos.UseCases;
using ControleDePedidos.UseCases.Gateways;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddScoped<IClienteUseCases, ClienteUseCases>();
            services.AddScoped<IClientePersistenceGateway, ClientePersistenceGateway>();
            services.AddScoped<IProdutoUseCases, ProdutoUseCases>();
            services.AddScoped<IProdutoPersistenceGateway, ProdutoPersistenceGateway>();
            services.AddScoped<IPedidoPersistenceGateway, PedidoPersistenceGateway>();
            services.AddScoped<IAcompanhamentoUseCases, AcompanhamentoUseCases>();
            services.AddScoped<IBuscarPedidoUseCase, BuscarPedidoUseCase>();
            services.AddScoped<IClienteUseCases, ClienteUseCases>();
            services.AddScoped<IPagamentoUseCases, PagamentoUseCases>();
            services.AddScoped<IProdutoUseCases, ProdutoUseCases>();
            services.AddScoped<IRealizarPedidoUseCase, RealizarPedidoUseCase>();
            services.AddScoped<IApiPagamentoGateway, MercadoPagoPagamentoGateway>();

            services.AddDbContext<ApplicationContext>();

            return services;
        }
    }
}