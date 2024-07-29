using Microsoft.EntityFrameworkCore;
using ProjetoGestaoVendas.Dominio.Entidades;
using ProjetoGestaoVendas.Repositorio.Configuracoes;

namespace ProjetoGestaoVendas.Repositorio.contexto
{
    public class Contexto : DbContext
    {
        public DbSet<Venda> Vendas { get; set; }
        private DbContextOptions<Contexto> _options;

        public Contexto() { }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VendaConfiguracao());
            modelBuilder.ApplyConfiguration(new TipoPagamentoConfiguracao());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_options == null)
                optionsBuilder.UseSqlServer("Server=DESKTOP-KQI45R3;Database=GestaoVendas;Trusted_Connection=True;");
        }
    }
}
