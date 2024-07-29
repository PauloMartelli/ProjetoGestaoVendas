using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoGestaoVendas.Dominio.Entidades;

namespace ProjetoGestaoVendas.Repositorio.Configuracoes;

public class VendaConfiguracao : IEntityTypeConfiguration<Venda>
{
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Venda> builder)
        {
                builder.HasKey(x => x.VendaID);

                builder.Property(x => x.VendaID)
                        .HasColumnName("VendaID")
                        .IsRequired();

                builder.Property(x => x.Valor)
                        .HasPrecision(18, 2)
                        .IsRequired();

                builder.Property(x => x.DataEHora)
                        .HasPrecision(0)
                        .IsRequired();

                builder.Property(x => x.Ativo)
                        .IsRequired();

                builder.HasOne(x => x.TipoPagamento)
                        .WithMany(t => t.Vendas)
                        .HasForeignKey(x => x.TipoPagamentoId);
        }
}