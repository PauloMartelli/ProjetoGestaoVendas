using ProjetoGestaoVendas.Dominio.Entidades;

namespace ProjetoGestaoVendas.Repositorio.Contratos;

public interface IVendaRepositorio
{
    Task<int> AdicionarVendaAsync(Venda venda);
    Task<Venda> ObterVendaPorIDAsync(int vendaID);
    Task<List<Venda>> ObterVendasAsync();
    Task AtualizarVendaAsync(Venda venda);
    Task<int> ExcluirVendaAsync(int vendaID);
}


