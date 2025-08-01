using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finis.Infra.Data.Mappings;

public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
{
    public void Configure(EntityTypeBuilder<Movimentacao> builder)
    {
        builder.ToTable("Movimentacao");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TipoGasto)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.DtMovimentacao)
       .IsRequired()
       .HasColumnType("date(10)");

        builder.Property(x => x.FlMovimentacao)
       .IsRequired()
       .HasColumnType("numeric(10)");

        builder.Property(x => x.ContaId)
       .IsRequired()
       .HasColumnType("numeric(10)");

        builder.Property(x => x.DescricaoMovimentacao)
         .IsRequired()
         .HasColumnType("varchar(255)");
        
        builder.Property(x => x.ValorMovimentacao)
        .IsRequired()
        .HasColumnType("numeric(38,2)");


    }    
}
