using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoGestaoVendas.Dominio.Entidades;

namespace ProjetoGestaoVendas.Repositorio.Configuracoes;

public class VendaConfiguracao : IEntityTypeConfiguration<Venda>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Venda> builder)
    {
        builder.HasKey(x => x.ID);

        builder.Property(x => x.ID)
                .HasColumnName("VendaID")
                .IsRequired();

        builder.Property(x => x.Valor)
                .HasPrecision(18, 2)
                .IsRequired();

        builder.Property(x => x.TipoPagamento)
                .IsRequired();

        builder.Property(x => x.DataEHora)
                .HasPrecision(0)
                .IsRequired();

        builder.Property(x => x.Ativo)
                .IsRequired();
    }
}