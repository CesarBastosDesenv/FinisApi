using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class RendimentoMap : IEntityTypeConfiguration<Rendimento>
{
    public void Configure(EntityTypeBuilder<Rendimento> builder)
    {
        builder.ToTable("Rendimento");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.AtivoId)
        .IsRequired()
        .HasColumnType("numeric(10)");

    //     builder.Property(x => x.TipoId)
    //    .IsRequired()
    //    .HasColumnType("numeric(10)");

        builder.Property(x => x.AnoRendimento)
       .IsRequired()
       .HasColumnType("varchar(50)");

        builder.Property(x => x.MesRendimento)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.QtdCotas)
        .IsRequired()
        .HasColumnType("numeric(10)");

        builder.Property(x => x.ValorRendimento)
         .IsRequired()
         .HasColumnType("numeric(38,2)");

            builder.Property(x => x.ValorRendimentoReais)
        .IsRequired()
        .HasColumnType("numeric(38,2)");

            builder.Property(x => x.FlBolsa)
        .IsRequired()
        .HasColumnType("varchar(50)");

         builder.Property(x => x.Corretora)
        .IsRequired()
        .HasColumnType("varchar(50)");
            
         builder.Property(x => x.DtRendimento)
        .IsRequired()
        .HasColumnType("date(10)");
    }
}
