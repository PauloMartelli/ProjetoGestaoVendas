using Microsoft.AspNetCore.Mvc;
using ProjetoGestaoVendas.API.Models.Venda.Requisicao;
using ProjetoGestaoVendas.Aplicacao.Contratos;
using ProjetoGestaoVendas.Dominio.Entidades;

namespace ProjetoGestaoVendas.API.Controllers
{
    [ApiController]
    [Route("vendas")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaApp _vendaApp;

        public VendaController(IVendaApp vendaApp)
        {
            _vendaApp = vendaApp;
        }

        [HttpPost("criar")]
        public async Task<IActionResult> AdicionarVenda([FromBody] VendaCriar vendaCriar)
        {
            try
            {
                Venda venda = new Venda
                {
                    Valor = vendaCriar.Valor,
                    TipoPagamentoId = vendaCriar.TipoPagamentoId,
                    DataEHora = DateTime.Now
                };

                var vendaId = await _vendaApp.AdicionarVendaAsync(venda);
                return Ok(vendaId);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao adicionar a venda: {ex.Message}");
            }
        }

        [HttpGet("obter/{vendaID}")]
        public async Task<IActionResult> ObterVendaPorID(int vendaID)
        {
            try
            {
                var venda = await _vendaApp.ObterVendaPorIDAsync(vendaID);
                if (venda == null)
                    return NotFound();

                return Ok(venda);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter a venda: {ex.Message}");
            }
        }

        [HttpGet("listar")]
        public async Task<IActionResult> ObterTodasVendas()
        {
            try
            {
                var vendas = await _vendaApp.ObterVendasAsync();
                return Ok(vendas);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao obter as vendas: {ex.Message}");
            }
        }

        [HttpPut("atualizar/{vendaID}")]
        public async Task<IActionResult> AtualizarVenda(int vendaID, [FromBody] VendaAtualizar vendaAtualizar)
        {
            try
            {
                var venda = new Venda
                {
                    VendaID = vendaID,
                    Valor = vendaAtualizar.Valor,
                    TipoPagamentoId = vendaAtualizar.TipoPagamentoId
                };

                await _vendaApp.AtualizarVendaAsync(venda);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao atualizar a venda: {ex.Message}");
            }
        }

        [HttpDelete("deletar/{vendaID}")]
        public async Task<IActionResult> DesativarVenda(int vendaID)
        {
            try
            {
                await _vendaApp.DesativarVendaAsync(vendaID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao desativar a venda: {ex.Message}");
            }
        }
    }
}
