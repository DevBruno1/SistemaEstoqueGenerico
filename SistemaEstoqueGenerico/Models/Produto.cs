namespace SistemaEstoqueGenerico.Models;

public class Produto
{

    public Produto(int id, string nome, int estoqueMinimo, string fornecedor)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do produto não pode ser vazio.", nameof(nome));

        if (id <= 0)
            throw new ArgumentException("O ID do produto deve ser maior que zero.", nameof(id));

        if (estoqueMinimo < 0)
            throw new ArgumentException("O estoque mínimo não pode ser negativo.", nameof(estoqueMinimo));

        if (string.IsNullOrWhiteSpace(fornecedor))
            throw new ArgumentException("O fornecedor do produto não pode ser vazio.", nameof(fornecedor));


        Id = id;
        Nome = nome;
        EstoqueMinimo = estoqueMinimo;
        Fornecedor = fornecedor;
    }
    public int Id { get; private set; }

    public string Nome { get; private set; }

    public int EstoqueMinimo { get; private set; }// Nível mínimo de estoque

    public string Fornecedor { get; private set; }// Fornecedor
}