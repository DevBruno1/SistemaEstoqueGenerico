using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using SistemaEstoqueGenerico.DTOs;
using SistemaEstoqueGenerico.Interfaces;
using SistemaEstoqueGenerico.Models;
using SistemaEstoqueGenerico.Repositories;

namespace SistemaEstoqueGenerico.Services;

public class EstoqueService : IEstoqueService
{
    private readonly IMovimentacaoEstoqueRepository _movimentacaoRepository;// Armazenar as movimentações em memória
    private readonly IEstoqueRepository _estoqueRepository;// Armazenar os estoques em memória

    public EstoqueService(IMovimentacaoEstoqueRepository movimentacaoRepository, IEstoqueRepository estoqueRepository)
    {
        _estoqueRepository = estoqueRepository;
        _movimentacaoRepository = movimentacaoRepository;
    }

    public MovimentacaoEstoque Entrada(EntradaEstoqueDTO dto)
    {

        var estoque = _estoqueRepository.ObterPorProduto(dto.ProdutoId)//isso faz com que o estoque seja buscado pelo id do produto
        ?? throw new Exception("Estoque nao encontrado");//se nao encontrar, lança uma exceção

        estoque.Adicionar(dto.Quantidade);//adiciona a quantidade ao estoque

        var movimentacao = new MovimentacaoEstoque(
            estoque,
            ETipoMovimentacao.Entrada,
            dto.Quantidade,
            dto.Responsavel,
            dto.Contexto
        );
        _movimentacaoRepository.Adicionar(movimentacao);

        return movimentacao;
    }

    public MovimentacaoEstoque Saida(SaidaEstoqueDTO dto)
    {
        var estoque = _estoqueRepository.ObterPorProduto(dto.ProdutoId)
            ?? throw new Exception("Estoque não encontrado");

        estoque.Remover(dto.Quantidade);

        var movimentacao = new MovimentacaoEstoque(
            estoque,
            ETipoMovimentacao.Saida,
            dto.Quantidade,
            dto.Responsavel,
            dto.Contexto
        );
        _movimentacaoRepository.Adicionar(movimentacao);

        return movimentacao;
    }


    public MovimentacaoEstoque Ajuste(AjusteEstoqueDTO dto)
    {
        var estoque = _estoqueRepository.ObterPorProduto(dto.ProdutoId)//isso faz com que o estoque seja buscado pelo id do produto
        ?? throw new Exception("Estoque nao encontrado");//se nao encontrar, lança uma exceção

        var quantidadeAtual = estoque.Quantidade;
        var diferenca = dto.QuantidadeFinal - quantidadeAtual;

        if (diferenca > 0)
        {
            estoque.Adicionar(diferenca);
        }
        else if (diferenca < 0)
        {
            estoque.Remover(Math.Abs(diferenca));
        }

        var movimentacao = new MovimentacaoEstoque(
            estoque,
            ETipoMovimentacao.Ajuste,
            diferenca,
            dto.Responsavel,
            dto.Contexto
        );

        _movimentacaoRepository.Adicionar(movimentacao);
        return movimentacao;
    }

    public void Transferencia(
        TransferenciaEstoqueDTO dto)
    {
        var origem = _estoqueRepository.ObterPorId(dto.EstoqueOrigemId)
            ?? throw new Exception("Estoque de origem não encontrado");

        var destino = _estoqueRepository.ObterPorId(dto.EstoqueDestinoId)
            ?? throw new Exception("Estoque de destino não encontrado");

        if (origem.Produto.Id != destino.Produto.Id)
            throw new Exception("Os produtos dos estoques de origem e destino devem ser iguais.");

        if (origem.Quantidade - dto.Quantidade < origem.Produto.EstoqueMinimo)
            throw new Exception("Quantidade insuficiente no estoque de origem.");

        origem.Remover(dto.Quantidade);
        destino.Adicionar(dto.Quantidade);

        _movimentacaoRepository.Adicionar(new MovimentacaoEstoque(
            origem,
            ETipoMovimentacao.Saida,
            dto.Quantidade,
            dto.Responsavel,
            $"Transferência para estoque {dto.EstoqueDestinoId}"
        ));

        _movimentacaoRepository.Adicionar(new MovimentacaoEstoque(
            destino,
            ETipoMovimentacao.Entrada,
            dto.Quantidade,
            dto.Responsavel,
            $"Transferência do estoque {dto.EstoqueOrigemId}"
        ));
    }

    public IEnumerable<MovimentacaoEstoque> ListarMovimentacoes()
    {
        return _movimentacaoRepository.Listar();
    }
}

// Services sao usados para encapsular a lógica de negócio da aplicação, coordenando operações entre repositórios e aplicando regras de negócio conforme necessário.