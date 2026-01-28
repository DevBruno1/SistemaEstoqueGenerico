using SistemaEstoqueGenerico.Interfaces;
using SistemaEstoqueGenerico.Models;

namespace SistemaEstoqueGenerico.Repositories;

public class EstoqueRepositoryMemoria : IEstoqueRepository
{
    private readonly List<Estoque> _estoques = new();// Lista para armazenar os estoques em memória

    public void Adicionar(Estoque estoque)// Adiciona um novo estoque à lista
    {
        _estoques.Add(estoque);// Adiciona o estoque à lista
    }

    public Estoque? ObterPorProduto(int produtoId)// Obtém o estoque de um produto específico pelo ID do produto
    {
        return _estoques.FirstOrDefault(e => e.Produto.Id == produtoId);// Retorna o estoque correspondente ou null se não encontrado
    }

    public Estoque? ObterPorId(int estoqueId)// Obtém o estoque por ID
    {
        return _estoques.FirstOrDefault(e => e.Id == estoqueId);// Retorna o estoque correspondente ou null se não encontrado
    }

    public IEnumerable<Estoque> Listar()
    {
        return _estoques;// Retorna todos os estoques armazenados
    }
}

// Repositories sao usados para encapsular a lógica de acesso a dados, fornecendo uma interface para operações de CRUD (Create, Read, Update, Delete) e abstraindo a fonte de dados subjacente.