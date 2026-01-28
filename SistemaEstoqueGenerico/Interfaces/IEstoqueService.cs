using System.Transactions;
using SistemaEstoqueGenerico.DTOs;
using SistemaEstoqueGenerico.Models;

namespace SistemaEstoqueGenerico.Interfaces;

public interface IEstoqueService
{
    public MovimentacaoEstoque Entrada(EntradaEstoqueDTO dto);

    public MovimentacaoEstoque Saida(SaidaEstoqueDTO dto);

    public MovimentacaoEstoque Ajuste(AjusteEstoqueDTO dto);
    public void Transferencia(TransferenciaEstoqueDTO dto);

    public IEnumerable<MovimentacaoEstoque> ListarMovimentacoes();
}