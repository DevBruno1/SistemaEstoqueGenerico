using SistemaEstoqueGenerico.Interfaces;
using SistemaEstoqueGenerico.Models;

namespace SistemaEstoqueGenerico.Repositories;

public class MovimentacaoEstoqueRepositoryMemoria : IMovimentacaoEstoqueRepository
{
    private readonly List<MovimentacaoEstoque> _movimentacoes = new();// Lista para armazenar as movimentações em memória

    public void Adicionar(MovimentacaoEstoque movimentacao)// Adiciona uma nova movimentação à lista
       => _movimentacoes.Add(movimentacao);// Adiciona a movimentação à lista

    public IEnumerable<MovimentacaoEstoque> Listar() => _movimentacoes;// Retorna todas as movimentações armazenadas
}


/*
essa classe implementa a interface IMovimentacaoEstoqueRepository para gerenciar movimentações de estoque em memória,
 permitindo adicionar e listar movimentações.

*/