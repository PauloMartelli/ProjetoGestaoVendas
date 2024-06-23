using Microsoft.EntityFrameworkCore;
using ProjetoGestaoVendas.Dominio.Entidades;
using ProjetoGestaoVendas.Repositorio.Configuracoes;

namespace ProjetoGestaoVendas.Repositorio.contexto
{
    public class Contexto : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendaConfiguracao());
        }
    }
}
