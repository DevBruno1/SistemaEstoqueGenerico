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
            var movimentacao = _estoqueService.Entrada(dto);// Chama o serviço de estoque para registrar a entrada
            return Ok(movimentacao);// Retorna a movimentação registrada
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, "Erro interno no servidor");
        }
    }

    [HttpPost("saida")]// Rota para registrar uma saída de estoque
    public IActionResult Saida([FromBody] SaidaEstoqueDTO dto)
    {
        try
        {
            var movimentacao = _estoqueService.Saida(dto);
            return Ok(movimentacao);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("transferencia")]
    public IActionResult Transferencia([FromBody] TransferenciaEstoqueDTO dto)
    {
        try
        {
            _estoqueService.Transferencia(dto);
            return Ok("Transferencia realizada com sucesso");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("movimentacoes")]
    public IActionResult Movimentacoes()
    {
        var movimentacoes = _estoqueService.ListarMovimentacoes();
        return Ok(movimentacoes);
    }


}