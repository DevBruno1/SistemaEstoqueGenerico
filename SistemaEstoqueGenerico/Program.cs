using SistemaEstoqueGenerico.DTOs;
using SistemaEstoqueGenerico.Models;
using SistemaEstoqueGenerico.Repositories;
using SistemaEstoqueGenerico.Services;

namespace SistemaEstoqueGenerico;

public class Program
{
    public static void Main(string[] args)
    {
        // ===== Infraestrutura =====
        var estoqueRepository = new EstoqueRepositoryMemoria();
        var movimentacaoRepository = new MovimentacaoEstoqueRepositoryMemoria();
        var estoqueService = new EstoqueService(movimentacaoRepository, estoqueRepository);

        // ===== Dados iniciais =====
        var produto = new Produto(
            id: 1,
            nome: "Produto Teste",
            estoqueMinimo: 5,
            fornecedor: "Fornecedor X"
        );

        estoqueRepository.Adicionar(new Estoque(1, produto, 10)); // Matriz
        estoqueRepository.Adicionar(new Estoque(2, produto, 3));  // Filial

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Sistema de Estoque ===");
            Console.WriteLine("1 - Entrada");
            Console.WriteLine("2 - Saída");
            Console.WriteLine("3 - Ajuste");
            Console.WriteLine("4 - Transferência");
            Console.WriteLine("5 - Listar Movimentações");
            Console.WriteLine("0 - Sair");
            Console.Write("Opção: ");

            var opcao = Console.ReadLine();

            if (opcao == "0")
                break;

            try
            {
                switch (opcao)
                {
                    case "1":
                        RegistrarEntrada(estoqueService);
                        break;
                    case "2":
                        RegistrarSaida(estoqueService);
                        break;
                    case "3":
                        RegistrarAjuste(estoqueService);
                        break;
                    case "4":
                        RegistrarTransferencia(estoqueService);
                        break;
                    case "5":
                        ListarMovimentacoes(estoqueService);
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }

    static void RegistrarEntrada(EstoqueService service)
    {
        Console.Write("Produto ID: ");
        var produtoId = int.Parse(Console.ReadLine());

        Console.Write("Quantidade: ");
        var quantidade = int.Parse(Console.ReadLine());

        Console.Write("Responsável: ");
        var responsavel = Console.ReadLine();

        Console.Write("Contexto: ");
        var contexto = Console.ReadLine();

        var dto = new EntradaEstoqueDTO
        {
            ProdutoId = produtoId,
            Quantidade = quantidade,
            Responsavel = responsavel,
            Contexto = contexto,
        };
        service.Entrada(dto);
        Console.WriteLine("Entrada registrada com sucesso.");
    }

    static void RegistrarSaida(EstoqueService service)
    {
        Console.Write("Produto ID: ");
        var produtoId = int.Parse(Console.ReadLine());

        Console.Write("Quantidade: ");
        var quantidade = int.Parse(Console.ReadLine());

        Console.Write("Responsável: ");
        var responsavel = Console.ReadLine();

        Console.Write("Contexto: ");
        var contexto = Console.ReadLine();

        var dto = new SaidaEstoqueDTO
        {
            ProdutoId = produtoId,
            Quantidade = quantidade,
            Responsavel = responsavel,
            Contexto = contexto
        };

        service.Saida(dto);
        Console.WriteLine("Saída registrada com sucesso.");
    }

    static void RegistrarAjuste(EstoqueService service)
    {
        Console.Write("Produto ID: ");
        var produtoId = int.Parse(Console.ReadLine());

        Console.Write("Quantidade final desejada: ");
        var quantidadeFinal = int.Parse(Console.ReadLine());

        Console.Write("Responsável: ");
        var responsavel = Console.ReadLine();

        Console.Write("Contexto: ");
        var contexto = Console.ReadLine();

        var dto = new AjusteEstoqueDTO
        {
            ProdutoId = produtoId,
            QuantidadeFinal = quantidadeFinal,
            Responsavel = responsavel,
            Contexto = contexto
        };

        service.Ajuste(dto);
        Console.WriteLine("Ajuste realizado com sucesso.");
    }

    static void RegistrarTransferencia(EstoqueService service)
    {
        Console.Write("Produto ID: ");
        var produtoId = int.Parse(Console.ReadLine());

        Console.Write("Estoque origem ID: ");
        var estoqueOrigemId = int.Parse(Console.ReadLine());

        Console.Write("Estoque destino ID: ");
        var estoqueDestinoId = int.Parse(Console.ReadLine());

        Console.Write("Quantidade: ");
        var quantidade = int.Parse(Console.ReadLine());

        Console.Write("Responsável: ");
        var responsavel = Console.ReadLine();

        Console.Write("Contexto: ");
        var contexto = Console.ReadLine();

        var dto = new TransferenciaEstoqueDTO
        {
            ProdutoId = produtoId,
            EstoqueOrigemId = estoqueOrigemId,
            EstoqueDestinoId = estoqueDestinoId,
            Quantidade = quantidade,
            Responsavel = responsavel,
            Contexto = contexto
        };

        service.Transferencia(dto);

        Console.WriteLine("Transferência realizada com sucesso.");
    }

    static void ListarMovimentacoes(EstoqueService service)
    {
        Console.WriteLine("\n--- HISTÓRICO DE MOVIMENTAÇÕES ---");

        foreach (var mov in service.ListarMovimentacoes())
        {
            Console.WriteLine($"{mov.Data:dd/MM/yyyy HH:mm} | {mov.Tipo} | {mov.Quantidade} | {mov.Contexto}");
        }
    }
}

