namespace SistemaEstoqueGenerico.DTOs;

public class EntradaEstoqueDTO
{
    public int ProdutoId { get; set; }
    public int Quantidade { get; set; }
    public string Responsavel { get; set; } = string.Empty;
    public string Contexto { get; set; } = string.Empty;
}