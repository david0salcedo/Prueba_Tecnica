using Microsoft.Extensions.Configuration;
using TEST.Repository;
using Microsoft.EntityFrameworkCore;
using TEST.Repository.Cliente;
using TEST.Repository.Persona;
using TEST.Repository.Cuenta;
using TEST.Repository.Movimiento;
using Microsoft.Extensions.Logging;
using TEST.Services.HandlerExeption;
using TEST.Services.LoggerManager;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRepositoryPersona, RepositoryPersona>();
builder.Services.AddSingleton<IRepositoryCliente, RepositoryCliente>();
builder.Services.AddSingleton<IRepositoryCuenta, RepositoryCuenta>();
builder.Services.AddSingleton<IRepositoryMovimiento, RepositoryMovimiento>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

using (ContextDB context = new ContextDB(builder.Configuration))
{
    context.Database.Migrate();
}

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
