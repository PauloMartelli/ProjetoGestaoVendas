using ProjetoGestaoVendas.Dominio.Enumeradores;

namespace ProjetoGestaoVendas.API.Models.Venda.Requisicao;

public class VendaCriar
{
    public decimal Valor { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
}