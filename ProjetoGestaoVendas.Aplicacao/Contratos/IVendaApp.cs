using ProjetoGestaoVendas.Dominio.Entidades;
namespace ProjetoGestaoVendas.Aplicacao.Contratos;

public interface IVendaApp
{
    public Task<int> AdicionarVendaAsync(Venda venda);
    public Task<Venda> ObterVendaPorIDAsync(int vendaID);
    public Task<List<Venda>> ObterVendasAsync();
    public Task AtualizarVendaAsync(Venda venda);
    public Task DesativarVendaAsync(int vendaID);
}