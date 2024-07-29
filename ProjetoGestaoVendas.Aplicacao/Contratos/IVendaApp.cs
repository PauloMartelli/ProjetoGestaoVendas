using ProjetoGestaoVendas.Dominio.Entidades;


namespace ProjetoGestaoVendas.Aplicacao.Contratos
{
    public interface IVendaApp
    {
        Task<int> AdicionarVendaAsync(Venda venda);
        Task<Venda> ObterVendaPorIDAsync(int vendaID);
        Task<IEnumerable<Venda>> ObterVendasAsync();
        Task AtualizarVendaAsync(Venda venda);
        Task DesativarVendaAsync(int vendaID);
    }
}
