using SistemaEstoqueGenerico.Interfaces;
using SistemaEstoqueGenerico.Repositories;
using SistemaEstoqueGenerico.Services;
using SistemaEstoqueGenerico.Api.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

//Controllers
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEstoqueRepository, EstoqueRepositoryMemoria>();// Injeção de dependência do repositório de estoque em memória
builder.Services.AddSingleton<IMovimentacaoEstoqueRepository, MovimentacaoEstoqueRepositoryMemoria>();// Injeção de dependência do repositório de movimentação de estoque em memória
builder.Services.AddScoped<IEstoqueService, EstoqueService>();// Injeção de dependência do serviço de estoque

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


using (var scope = app.Services.CreateScope())
{
    var estoqueRepo = scope.ServiceProvider.GetRequiredService<IEstoqueRepository>();
    DataSeeder.Seed(estoqueRepo);
}

app.Run();



