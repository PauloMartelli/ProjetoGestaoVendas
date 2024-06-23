using Microsoft.EntityFrameworkCore;
using ProjetoGestaoVendas.Dominio.Entidades;
using ProjetoGestaoVendas.Dominio.Enumeradores;
using ProjetoGestaoVendas.Repositorio.contexto;
using ProjetoGestaoVendas.Repositorio.Contratos;
using System.Data;

namespace ProjetoGestaoVendas.Repositorio;

public class VendaRepositorio : IVendaRepositorio
{
    private readonly Contexto _contexto;

    public VendaRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<int> AdicionarVendaAsync(Venda venda)
    {
        using (var connection = _contexto.Database.GetDbConnection())
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "AdicionarVenda";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Valor", venda.Valor));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@TipoPagamento", (int)venda.TipoPagamento));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@DataEHora", venda.DataEHora));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Ativo", venda.Ativo));

                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }
    }

    public async Task<Venda> ObterVendaPorIDAsync(int vendaID)
    {
        using (var connection = _contexto.Database.GetDbConnection())
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "ObterVendaPorID";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@VendaID", vendaID));

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Venda
                        {
                            ID = reader.GetInt32(0),
                            Valor = reader.GetDecimal(1),
                            TipoPagamento = (TipoPagamento)reader.GetInt32(2),
                            DataEHora = reader.GetDateTime(3),
                            Ativo = reader.GetBoolean(4)
                        };
                    }
                    return null;
                }
            }
        }
    }

    public async Task<List<Venda>> ObterVendasAsync()
    {
        var vendas = new List<Venda>();
        using (var connection = _contexto.Database.GetDbConnection())
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "ObterVendas";
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        vendas.Add(new Venda
                        {
                            ID = reader.GetInt32(0),
                            Valor = reader.GetDecimal(1),
                            TipoPagamento = (TipoPagamento)reader.GetInt32(2),
                            DataEHora = reader.GetDateTime(3),
                            Ativo = reader.GetBoolean(4)
                        });
                    }
                }
            }
        }
        return vendas;
    }

    public async Task AtualizarVendaAsync(Venda venda)
    {
        using (var connection = _contexto.Database.GetDbConnection())
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "AtualizarVenda";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@VendaID", venda.ID));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Valor", venda.Valor));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@TipoPagamento", (int)venda.TipoPagamento));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@DataEHora", venda.DataEHora));
                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@Ativo", venda.Ativo));

                await command.ExecuteNonQueryAsync();
            }
        }
    }

    public async Task<int> ExcluirVendaAsync(int vendaID)
    {
        using (var connection = _contexto.Database.GetDbConnection())
        {
            await connection.OpenAsync();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DesativarVenda";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new Microsoft.Data.SqlClient.SqlParameter("@VendaID", vendaID));

                return await command.ExecuteNonQueryAsync();
            }
        }
    }
}

