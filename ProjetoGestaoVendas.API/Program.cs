using Microsoft.EntityFrameworkCore;
using ProjetoGestaoVendas.Aplicacao;
using ProjetoGestaoVendas.Aplicacao.Contratos;
using ProjetoGestaoVendas.Repositorio;
using ProjetoGestaoVendas.Repositorio.contexto;
using ProjetoGestaoVendas.Repositorio.Contratos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IVendaApp, VendaApp>();

builder.Services.AddScoped<IVendaRepositorio, VendaRepositorio>();

builder.Services.AddDbContext<Contexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
