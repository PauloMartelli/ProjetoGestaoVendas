namespace ProjetoGestaoVendas.Dominio.Entidades;

public class TipoPagamento
{
    public int TipoPagamentoId { get; set; }
    public string Nome { get; set; }
    public List<Venda> Vendas { get; set; }
}