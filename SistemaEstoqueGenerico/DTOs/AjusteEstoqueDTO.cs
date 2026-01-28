namespace SistemaEstoqueGenerico.DTOs;

public class AjusteEstoqueDTO
{
    public int ProdutoId { get; set; }

    public int QuantidadeFinal { get; set; }

    public string Responsavel { get; set; } = string.Empty;

    public string Contexto { get; set; } = string.Empty;
}

//DTOs sao usados para transferir dados entre diferentes partes do sistema, como entre a camada de serviço e a camada de apresentação.