using ProjetoGestaoVendas.Dominio.Enumeradores;

namespace ProjetoGestaoVendas.Dominio.Entidades;

public class Venda
{
    public int ID { get; set; }
    public decimal Valor { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
    public DateTime DataEHora { get; set; }
    public bool Ativo { get; set; } = true;
}