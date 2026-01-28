namespace SistemaEstoqueGenerico.DTOs;

public class SaidaEstoqueDTO
{
    public int ProdutoId { get; set; }

    public int Quantidade { get; set; }

    public string Responsavel { get; set; } = string.Empty;

    public string Contexto { get; set; } = string.Empty;//isso quer dizer que o campo contexto é uma string que não pode ser nula e é inicializada com uma string vazia por padrão
}