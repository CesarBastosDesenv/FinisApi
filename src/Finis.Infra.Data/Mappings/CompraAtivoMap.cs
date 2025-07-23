using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class CompraAtivoMap : IEntityTypeConfiguration<CompraAtivo>
{
    public void Configure(EntityTypeBuilder<CompraAtivo> builder)
    {
        builder.ToTable("CompraAtivo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeAtivo)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.AtivoId)
       .IsRequired()
       .HasColumnType("numeric(10)");

        builder.Property(x => x.DtCompra)
       .IsRequired()
       .HasColumnType("date(10)");

        builder.Property(x => x.ValorCompra)
         .IsRequired()
         .HasColumnType("numeric(38,2)");

        builder.Property(x => x.EstimativaVenda)
        .IsRequired()
        .HasColumnType("numeric(38,2)");

        builder.Property(x => x.ValorCota)
        .IsRequired()
        .HasColumnType("numeric(38,2)");

        builder.Property(x => x.QtdCotas)
        .IsRequired()
        .HasColumnType("numeric(10)");

        builder.Property(x => x.FlVendido)
        .HasDefaultValue(true);

        builder.Property(x => x.FlBolsa)
        .HasColumnType("varchar(50)");

        builder.Property(x => x.Corretora)
        .HasColumnType("varchar(50)");

        builder.Property(x => x.Estrategia)
        .HasColumnType("varchar(50)");
    }
}
