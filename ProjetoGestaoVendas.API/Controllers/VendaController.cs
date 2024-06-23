using Microsoft.AspNetCore.Mvc;
using ProjetoGestaoVendas.API.Models.Venda.Requisicao;
using ProjetoGestaoVendas.Aplicacao.Contratos;
using ProjetoGestaoVendas.Dominio.Entidades;

namespace ProjetoGestaoVendas.API.Controllers;

[ApiController]
[Route("[Controller]")]
public class VendaController : Controller
{
    private readonly IVendaApp _vendaApp;

    public VendaController(IVendaApp vendaApp)
    {
        _vendaApp = vendaApp;
    }

    [HttpPost("Adicionar")]
    public async Task<IActionResult> AdicionarVendaAsync([FromBody] VendaCriar venda)
    {
        try
        {
            var vendaId = await _vendaApp.AdicionarVendaAsync(new Venda()
            {
                Valor = venda.Valor,
                TipoPagamento = venda.TipoPagamento,
                DataEHora = DateTime.Now
            });
            return Ok(new { id = vendaId });
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao adicionar a venda: " + ex.Message);
        }
    }

    [HttpGet("Obter/{id}")]
    public async Task<IActionResult> ObterVendaPorIDAsync(int id)
    {
        try
        {
            var venda = await _vendaApp.ObterVendaPorIDAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao obter a venda: " + ex.Message);
        }
    }

    [HttpGet("Listar")]
    public async Task<IActionResult> ObterVendasAsync()
    {
        try
        {
            var vendas = await _vendaApp.ObterVendasAsync();
            return Ok(vendas);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao obter as vendas: " + ex.Message);
        }
    }

    [HttpPut("Atualizar")]
    public async Task<IActionResult> AtualizarVendaAsync([FromBody] VendaAtualizar venda)
    {
        try
        {
            await _vendaApp.AtualizarVendaAsync(new Venda()
            {
                ID = venda.ID,
                Valor = venda.Valor,
                TipoPagamento = venda.TipoPagamento
            });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao atualizar a venda: " + ex.Message);
        }
    }

    [HttpDelete("Deletar/{id}")]
    public async Task<IActionResult> DesativarVendaAsync(int id)
    {
        try
        {
            await _vendaApp.DesativarVendaAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro ao desativar a venda: " + ex.Message);
        }
    }
}
