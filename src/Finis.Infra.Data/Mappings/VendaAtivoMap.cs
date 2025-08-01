using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class VendaAtivoMap : IEntityTypeConfiguration<VendaAtivo>
{
    public void Configure(EntityTypeBuilder<VendaAtivo> builder)
    {
        builder.ToTable("VendaAtivo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompraId)
        .IsRequired()
        .HasColumnType("numeric(10)");

        builder.Property(x => x.AtivoId)
       .IsRequired()
       .HasColumnType("numeric(10)");

        builder.Property(x => x.DtVenda)
       .IsRequired()
       .HasColumnType("date(10)");

        builder.Property(x => x.ValorVenda)
         .IsRequired()
         .HasColumnType("numeric(38,2)");

        builder.Property(x => x.TotalTaxas)
         .IsRequired()
         .HasColumnType("numeric(38,2)");

        builder.Property(x => x.ValorLucro)
         .IsRequired()
         .HasColumnType("numeric(38,2)");

        builder.Property(x => x.ValorLucroReais)
       .IsRequired()
       .HasColumnType("numeric(38,2)");

        builder.Property(x => x.ValorRecebido)
         .IsRequired()
         .HasColumnType("numeric(38,2)"); 
         
         builder.Property(x => x.FlBolsa)
        .IsRequired()
        .HasColumnType("varchar(50)");
    }
}
