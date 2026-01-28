using SistemaEstoqueGenerico.Models;
using Xunit;
using SistemaEstoqueGenerico.DTOs;
using SistemaEstoqueGenerico.Services;
using SistemaEstoqueGenerico.Repositories;

namespace SistemaEstoqueGenerico.Tests.Services;

public class EstoqueServiceTests
{
    [Fact]
    public void Entrada_DeveAdicionarQuantidadeERegistrarMovimentacao()
    {
        //arrange (preparação)

        var produto = new Produto(1, "Produto Teste", 5, "Fornecedor X");
        var estoque = new Estoque(1, produto, 10);

        var estoqueRepository = new EstoqueRepositoryMemoria();// Repositório em memória para testes
        estoqueRepository.Adicionar(estoque);// Adiciona o estoque inicial

        var movimentacaoRepository = new MovimentacaoEstoqueRepositoryMemoria();// Repositório em memória para testes

        var service = new EstoqueService(movimentacaoRepository, estoqueRepository);

        var dto = new EntradaEstoqueDTO
        {
            ProdutoId = 1,
            Quantidade = 5,
            Responsavel = "Usuario Teste",
            Contexto = "Teste de entrada",
        };

        var movimentacao = service.Entrada(dto);

        Assert.Equal(15, estoque.Quantidade);// Verifica se a quantidade foi atualizada
        Assert.Equal(ETipoMovimentacao.Entrada, movimentacao.Tipo);// Verifica o tipo de movimentação
        Assert.Equal(5, movimentacao.Quantidade);// Verifica a quantidade da movimentação
        Assert.Single(movimentacaoRepository.Listar());// Verifica se a movimentação foi registrada
    }

    [Fact]
    public void Saida_DeveLancarExcecao_QuandoQuantidadeAbaixoDoMinimo()
    {
        var produto = new Produto(1, "ProdutoTeste", 5, "Fornecedor X");
        var estoque = new Estoque(1, produto, quantidadeInicial: 6);

        var estoqueRepository = new EstoqueRepositoryMemoria();
        estoqueRepository.Adicionar(estoque);

        var movimentacaoRepository = new MovimentacaoEstoqueRepositoryMemoria();

        var service = new EstoqueService(movimentacaoRepository, estoqueRepository);

        var dto = new SaidaEstoqueDTO
        {
            ProdutoId = 1,
            Quantidade = 2,
            Responsavel = "Usuario Teste",
            Contexto = "Teste de saida invalido"
        };

        var ex = Assert.Throws<InvalidOperationException>(() => service.Saida(dto));// Verifica se a exceção foi lançada
        Assert.Contains("minimo", ex.Message, StringComparison.OrdinalIgnoreCase);// Verifica a mensagem da exceção
    }

    [Fact]
    public void Transferencia_DeveMoverQuantidadeERegistrarDuasMovimentacoes()
    {
        var produto = new Produto(1, "Produto Teste", 5, "Fornecedor X");

        var estoqueOrigem = new Estoque(1, produto, 10);
        var estoqueDestino = new Estoque(2, produto, 20);

        var estoqueRepository = new EstoqueRepositoryMemoria();
        estoqueRepository.Adicionar(estoqueOrigem);
        estoqueRepository.Adicionar(estoqueDestino);

        var movimentacaoRepository = new MovimentacaoEstoqueRepositoryMemoria();

        var service = new EstoqueService(movimentacaoRepository, estoqueRepository);

        var dto = new TransferenciaEstoqueDTO
        {
            ProdutoId = 1,
            EstoqueOrigemId = estoqueOrigem.Id,
            EstoqueDestinoId = estoqueDestino.Id,
            Quantidade = 4,
            Responsavel = "Usuario Teste",
            Contexto = "Teste de transferencia"
        };

        service.Transferencia(dto);

        Assert.Equal(6, estoqueOrigem.Quantidade);// Verifica a quantidade no estoque de origem
        Assert.Equal(24, estoqueDestino.Quantidade);// Verifica a quantidade no estoque de destino

        var movimentacoes = movimentacaoRepository.Listar().ToList();// Obtém todas as movimentações registradas

        Assert.Equal(2, movimentacoes.Count);// Verifica se duas movimentações foram registradas
        Assert.Contains(movimentacoes, m => m.Tipo == ETipoMovimentacao.Saida);// Verifica a movimentação de saída
        Assert.Contains(movimentacoes, m => m.Tipo == ETipoMovimentacao.Entrada);// Verifica a movimentação de entrada
    }
}