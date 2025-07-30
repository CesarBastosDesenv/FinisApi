using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class ContaMap : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.ToTable("Conta");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeConta)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.ContaPaiId)
        .IsRequired()
        .HasColumnType("numeric(10)");

        builder.Property(x => x.ValorSaldo)
        .IsRequired()
        .HasColumnType("numeric(38,2)");

        builder.Property(x => x.DataCriacao)
       .IsRequired()
       .HasColumnType("date(20)");

        builder.Property(x => x.Instituicao)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.Status)
        .HasDefaultValue(true);

       
    }
}
