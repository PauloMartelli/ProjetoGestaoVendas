using ProjetoGestaoVendas.Dominio.Entidades;
using ProjetoGestaoVendas.Repositorio.Contratos;

namespace ProjetoGestaoVendas.Aplicacao
{
    public class VendaApp : IVendaApp
    {
        private readonly IVendaRepositorio _vendaRepositorio;

        public VendaApp(IVendaRepositorio vendaRepositorio)
        {
            _vendaRepositorio = vendaRepositorio;
        }

        public async Task<int> AdicionarVendaAsync(Venda venda)
        {
            if (venda == null)
                throw new ArgumentNullException("A venda não pode ser nula.");

            return await _vendaRepositorio.AdicionarVendaAsync(venda);
        }

        public async Task<Venda> ObterVendaPorIDAsync(int vendaID)
        {
            if (vendaID <= 0)
                throw new ArgumentException("O ID da venda deve ser maior que zero.");

            return await _vendaRepositorio.ObterVendaPorIDAsync(vendaID);
        }

        public async Task<List<Venda>> ObterVendasAsync()
        {
            return await _vendaRepositorio.ObterVendasAsync();
        }

        public async Task AtualizarVendaAsync(Venda venda)
        {
            if (venda == null)
                throw new ArgumentNullException("A venda não pode ser nula.");

            await _vendaRepositorio.AtualizarVendaAsync(venda);
        }

        public async Task DesativarVendaAsync(int vendaID)
        {
            if (vendaID <= 0)
                throw new ArgumentException("O ID da venda deve ser maior que zero.");

            await _vendaRepositorio.ExcluirVendaAsync(vendaID);
        }
    }
}
