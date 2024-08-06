using ControleDePedidos.Application;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Infrastructure.Adapters;
using ControleDePedidos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>();

// Configure DI
builder.Services.AddScoped<IClienteApplication, ClienteApplication>();
builder.Services.AddScoped<IClientePersistencePort, ClientePersistenceAdapter>();
builder.Services.AddScoped<IProdutoApplication, ProdutoApplication>();
builder.Services.AddScoped<IProdutoPersistencePort, ProdutoPersistenceAdapter>();
builder.Services.AddScoped<IPedidoApplication, PedidoApplication>();
builder.Services.AddScoped<IPedidoPersistencePort, PedidoPersistenceAdapter>();

var app = builder.Build();

// Run migrations if needed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
