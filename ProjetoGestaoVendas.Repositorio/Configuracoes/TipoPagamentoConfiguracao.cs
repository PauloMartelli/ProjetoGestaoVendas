using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoGestaoVendas.Dominio.Entidades;

namespace ProjetoGestaoVendas.Repositorio.Configuracoes;

public class TipoPagamentoConfiguracao : IEntityTypeConfiguration<TipoPagamento>
{
    public void Configure(EntityTypeBuilder<TipoPagamento> builder)
    {
        builder.HasKey(x => x.TipoPagamentoId);

        builder.Property(x => x.TipoPagamentoId)
                .IsRequired();

        builder.Property(x => x.Nome)
                .HasColumnType("varchar(30)")
                .IsRequired();
    }
}