namespace SistemaEstoqueGenerico.Models;

public class Estoque
{
    public Estoque(int id, Produto produto, int quantidadeInicial)
    {
        Id = id;
        Produto = produto ?? throw new ArgumentNullException(nameof(produto), "O produto não pode ser nulo.");

        if (quantidadeInicial < 0)
            throw new ArgumentException("A quantidade em estoque não pode ser negativa.", nameof(quantidadeInicial));


        Quantidade = quantidadeInicial;
    }

    public int Id { get; private set; }
    public Produto Produto { get; private set; }

    public int Quantidade { get; private set; }

    public void Adicionar(int quantia)
    {
        if (quantia <= 0)
            throw new ArgumentException("A quantidade a ser adicionada deve ser maior que zero.", nameof(quantia));

        Quantidade += quantia;
    }
    public void Remover(int quantia)
    {
        if (quantia <= 0)
            throw new ArgumentException("A quantidade a ser removida deve ser maior que zero.", nameof(quantia));

        if (quantia > Quantidade)
            throw new InvalidOperationException("Não há estoque suficiente para remover a quantidade solicitada.");

        if (Quantidade - quantia < Produto.EstoqueMinimo)
            throw new InvalidOperationException("A remocao desta quantidade deixaria o estoque abaixo do minimo.");

        Quantidade -= quantia;
    }
}

//Models sao usados para representar entidades do domínio do sistema, encapsulando dados e comportamentos relacionados a essas entidades.