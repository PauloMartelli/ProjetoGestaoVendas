using ProjetoGestaoVendas.Dominio.Entidades;

public interface IVendaApp
{
    public Task<int> AdicionarVendaAsync(Venda venda);
    public Task<Venda> ObterVendaPorIDAsync(int vendaID);
    public Task<List<Venda>> ObterVendasAsync();
    public Task AtualizarVendaAsync(Venda venda);
    public Task DesativarVendaAsync(int vendaID);
}