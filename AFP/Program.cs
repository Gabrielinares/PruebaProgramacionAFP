using Business.Services.Depto;
using Business.Services;
using DataAccess.Models;
using DataAccess.Repositories.Depto;
using layer.access.Repositories;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDepartamentoRepository<Departamento>, DepartamentoRepository<Departamento>>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IEmpresaRepository<Empresa>, EmpresaRepository<Empresa>>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services
    .AddDbContext<BDContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("Produccion"), sqlServerOptions => sqlServerOptions.CommandTimeout(300)
    ));
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
