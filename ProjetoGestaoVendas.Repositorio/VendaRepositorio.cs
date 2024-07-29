using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using ProjetoGestaoVendas.Dominio.Entidades;
using ProjetoGestaoVendas.Repositorio.Contratos;
using Microsoft.Data.SqlClient;

public class VendaRepositorio : IVendaRepositorio
{
    private readonly string _connectionString;

    public VendaRepositorio(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection GetConnection() => new SqlConnection(_connectionString);

    public async Task<int> AdicionarVendaAsync(Venda venda)
    {
        using (var connection = GetConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Valor", venda.Valor);
            parameters.Add("@TipoPagamentoId", venda.TipoPagamentoId);
            parameters.Add("@DataEHora", venda.DataEHora);
            parameters.Add("@Ativo", venda.Ativo);

            var vendaID = await connection.ExecuteScalarAsync<int>("sp_AdicionarVenda", parameters, commandType: CommandType.StoredProcedure);
            return vendaID;
        }
    }

    public async Task<Venda> ObterVendaPorIDAsync(int vendaID)
    {
        using (var connection = GetConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VendaID", vendaID);

            return await connection.QuerySingleOrDefaultAsync<Venda>("sp_ObterVendaPorId", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task<IEnumerable<Venda>> ObterVendasAsync()
    {
        using (var connection = GetConnection())
        {
            return await connection.QueryAsync<Venda>("sp_ObterVendas", commandType: CommandType.StoredProcedure);
        }
    }

    public async Task AtualizarVendaAsync(Venda venda)
    {
        using (var connection = GetConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VendaID", venda.VendaID);
            parameters.Add("@Valor", venda.Valor);
            parameters.Add("@TipoPagamentoId", venda.TipoPagamentoId);
            parameters.Add("@DataEHora", venda.DataEHora);
            parameters.Add("@Ativo", venda.Ativo);

            await connection.ExecuteAsync("sp_AtualizarVenda", parameters, commandType: CommandType.StoredProcedure);
        }
    }

    public async Task DesativarVendaAsync(int vendaID)
    {
        using (var connection = GetConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@VendaID", vendaID);

            await connection.ExecuteAsync("sp_DesativarVenda", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
