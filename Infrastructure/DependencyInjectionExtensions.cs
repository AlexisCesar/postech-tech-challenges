using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Application;
using ControleDePedidos.Infrastructure.Adapters;
using ControleDePedidos.Infrastructure.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
            services.AddScoped<IClientePersistencePort, ClientePersistenceAdapter>();
            services.AddScoped<IProdutoApplication, ProdutoApplication>();
            services.AddScoped<IProdutoPersistencePort, ProdutoPersistenceAdapter>();
            services.AddScoped<IPedidoApplication, PedidoApplication>();
            services.AddScoped<IPedidoPersistencePort, PedidoPersistenceAdapter>();

            services.AddDbContext<ApplicationContext>();

            return services;
        }
    }
}