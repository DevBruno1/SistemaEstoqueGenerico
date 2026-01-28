namespace SistemaEstoqueGenerico.DTOs;

public class TransferenciaEstoqueDTO
{
    public int ProdutoId { get; set; }

    public int EstoqueOrigemId { get; set; }

    public int EstoqueDestinoId { get; set; }

    public int Quantidade { get; set; }

    public string Responsavel { get; set; } = string.Empty;

    public string Contexto { get; set; } = string.Empty;
}