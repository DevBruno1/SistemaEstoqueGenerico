using Microsoft.AspNetCore.Mvc;
using SistemaEstoqueGenerico.DTOs;
using SistemaEstoqueGenerico.Interfaces;
using SistemaEstoqueGenerico.Models;


namespace SistemaEstoqueGenerico.Api.Controllers;

[ApiController]
[Route("api/estoque")]

public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _estoqueService;

    public EstoqueController(IEstoqueService estoqueService)// Construtor do controlador de estoque
    {
        _estoqueService = estoqueService;// Injeção de dependência do serviço de estoque
    }

    [HttpPost("entrada")]// Rota para registrar uma entrada de estoque
    public IActionResult Entrada([FromBody] EntradaEstoqueDTO dto)// Método para registrar uma entrada de estoque
    {
        try
        {
            var movimentacao = _estoqueService.Entrada(dto);
            return Ok(new
            {
                sucesso = true,
                mensagem = "Entrada de estoque realizada com sucesso.",
                dados = movimentacao
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                sucesso = false,
                mensagem = ex.Message
            });
        }
    }



    [HttpPost("saida")]// Rota para registrar uma saída de estoque
    public IActionResult Saida([FromBody] SaidaEstoqueDTO dto)
    {
        try
        {
            var movimentacao = _estoqueService.Saida(dto);
            return Ok(
                new
                {
                    sucesso = true,
                    mensagem = "Saida de estoque realizada com sucesso",
                    dados = movimentacao
                });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                sucesso = false,
                mensagem = ex.Message
            });
        }
    }



    [HttpPost("transferencia")]
    public IActionResult Transferencia([FromBody] TransferenciaEstoqueDTO dto)
    {
        try
        {
            _estoqueService.Transferencia(dto);
            return Ok(new
            {
                sucesso = true,
                mensagem = "Transferencia realizada com sucesso"
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                sucesso = false,
                mensagem = ex.Message
            });
        }
    }



    [HttpGet("movimentacoes")]
    public IActionResult Movimentacoes()
    {
        var movimentacoes = _estoqueService.ListarMovimentacoes();
        return Ok(new
        {
            sucesso = true,
            dados = movimentacoes
        });
    }
}