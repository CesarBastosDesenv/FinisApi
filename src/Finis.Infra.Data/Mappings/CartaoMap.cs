using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class CartaoMap : IEntityTypeConfiguration<Cartao>
{
public void Configure(EntityTypeBuilder<Cartao> builder)
    {
        builder.ToTable("Cartao");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NomeCartao)
        .IsRequired()
        .HasColumnType("varchar(50)");
        
        builder.Property(x => x.DtCadastro)
       .IsRequired()
       .HasColumnType("date(10)");

        builder.Property(x => x.InstituicaoBancaria)
        .HasColumnType("varchar(50)");

        builder.Property(x => x.Ativo)
         .HasColumnType("bit");

    }

   
}
