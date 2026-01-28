namespace SistemaEstoqueGenerico.Models;

public class MovimentacaoEstoque
{
    public MovimentacaoEstoque(Estoque estoque, ETipoMovimentacao tipo, int quantidade, string responsavel, string contexto)
    {
        if (estoque == null)
            throw new ArgumentNullException(nameof(estoque), "O estoque nao pode ser nulo");

        if (quantidade <= 0)
            throw new ArgumentException("A quantidade deve ser maior que zero.", nameof(quantidade));

        if (string.IsNullOrWhiteSpace(responsavel))
            throw new ArgumentException("O responsavel nao pode ser nulo", nameof(responsavel));

        if (string.IsNullOrWhiteSpace(contexto))
            throw new ArgumentException("Por favor insira o contexto", nameof(contexto));

        Estoque = estoque;
        Tipo = tipo;
        Quantidade = quantidade;
        Data = DateTime.Now;
        Responsavel = responsavel;
        Contexto = contexto;
    }

    public Estoque Estoque { get; private set; }

    public ETipoMovimentacao Tipo { get; private set; }

    public int Quantidade { get; private set; }

    public DateTime Data { get; private set; }

    public string Responsavel { get; private set; }

    public string Contexto { get; private set; }
}