using SistemaEstoqueGenerico.Models;

namespace SistemaEstoqueGenerico.Interfaces;

public interface IMovimentacaoEstoqueRepository
{
    void Adicionar(MovimentacaoEstoque movimentacao);

    IEnumerable<MovimentacaoEstoque> Listar();
}