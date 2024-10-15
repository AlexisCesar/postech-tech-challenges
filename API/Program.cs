using ControleDePedidos.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure DI
builder.Services.AddInfrastructure();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Adiciona o health check na rota "/health"
app.MapHealthChecks("/health");

// Run migrations if needed
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    services.EnsureDatabaseMigrated();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
