using Microsoft.EntityFrameworkCore;
using ProjetoGestaoVendas.Dominio.Entidades;
using ProjetoGestaoVendas.Repositorio.Configuracoes;

namespace ProjetoGestaoVendas.Repositorio.contexto
{
    public class Contexto : DbContext
    {
        private DbContextOptions _options;
        public DbSet<Venda> Vendas { get; set; }

        public Contexto() { }

        public Contexto(DbContextOptions options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendaConfiguracao());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
                optionsBuilder.UseSqlServer("SERVER=DESKTOP-KQI45R3;Database=GestaoVendasDB;Trusted-Connection=true;");
        }
    }
}
