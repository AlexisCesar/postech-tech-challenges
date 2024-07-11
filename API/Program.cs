using ControleDePedidos.Application;
using ControleDePedidos.Application.Interfaces;
using ControleDePedidos.Application.Ports;
using ControleDePedidos.Infrastructure.Adapters;
using ControleDePedidos.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationContext>();

// Configure DI
builder.Services.AddScoped<IClienteApplication, ClienteApplication>();
builder.Services.AddScoped<IClientePersistancePort, ClientePersistanceAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
