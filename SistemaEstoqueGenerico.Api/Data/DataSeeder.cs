using System.Data.Common;
using Microsoft.VisualBasic;
using SistemaEstoqueGenerico.Interfaces;
using SistemaEstoqueGenerico.Models;

namespace SistemaEstoqueGenerico.Api.Data;

public class DataSeeder
{
    public static void Seed(IEstoqueRepository estoqueRepository)
    {
        var produto = new Produto(
            id: 1,
            nome: "Produto Padrao",
            estoqueMinimo: 5,
            fornecedor: "Fornecedor Teste"
        );

        var estoque1 = new Estoque(
            id: 1,
            produto: produto,
            quantidadeInicial: 20
        );

        var estoque2 = new Estoque(
            id: 2,
            produto: produto,
            quantidadeInicial: 10
        );

        estoqueRepository.Adicionar(estoque1);
        estoqueRepository.Adicionar(estoque2);
    }
}