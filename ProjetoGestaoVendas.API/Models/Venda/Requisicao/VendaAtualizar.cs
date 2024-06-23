using ProjetoGestaoVendas.Dominio.Enumeradores;

namespace ProjetoGestaoVendas.API.Models.Venda.Requisicao;

public class VendaAtualizar
{
    public int ID { get; set; }
    public decimal Valor { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
}