using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class AtivoMap : IEntityTypeConfiguration<Ativo>
{


    public void Configure(EntityTypeBuilder<Ativo> builder)
    {
        builder.ToTable("Ativo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeAtivo)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.NomeAtivoCompleto)
        .IsRequired()
        .HasColumnType("varchar(255)");

        builder.Property(x => x.SeguimentoAtivo)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.TipoAtivoId)
       .IsRequired()
       .HasColumnType("numeric(10)");

        builder.Property(x => x.QtdCotas)
        .IsRequired()
        .HasColumnType("decimal(18,8)");

        builder.Property(x => x.FlVendido)
         .HasColumnType("bit");

        builder.Property(x => x.DtCadastro)
       .IsRequired()
       .HasColumnType("date(10)");

        builder.Property(x => x.Imagem)
        .HasColumnType("varchar(50)");

        builder.HasMany(x => x.CompraAtivos)
       .WithOne(y => y.Ativo)
       .HasForeignKey(x => x.Id);
        
        builder.HasMany(x => x.Rendimentos)
        .WithOne(y => y.Ativo)
        .HasForeignKey(x => x.Id);
    }
}
