using SistemaEstoqueGenerico.Models;

namespace SistemaEstoqueGenerico.Interfaces;

public interface IEstoqueRepository
{
    void Adicionar(Estoque estoque);// Adiciona um novo estoque
    Estoque? ObterPorProduto(int produtoId);// Obtém o estoque de um produto específico]
    Estoque? ObterPorId(int estoqueId);// Obtém o estoque por ID
    IEnumerable<Estoque> Listar();// Lista todos os estoques
}

//Interfaces sao usadas para definir contratos que as classes devem seguir, promovendo a abstração e facilitando a manutenção do código.