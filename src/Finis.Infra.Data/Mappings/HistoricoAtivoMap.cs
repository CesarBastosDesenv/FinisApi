using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class HistoricoAtivoMap : IEntityTypeConfiguration<HistoricoAtivo>
{
    public void Configure(EntityTypeBuilder<HistoricoAtivo> builder)
    {
        builder.ToTable("HistoricoAtivo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Descricao)
        .IsRequired()
        .HasColumnType("int(255)");

        builder.Property(x => x.AtivoId)
       .IsRequired()
       .HasColumnType("numeric(10)");

        builder.Property(x => x.DtHistorico)
       .IsRequired()
       .HasColumnType("date(10)");

    }
}
