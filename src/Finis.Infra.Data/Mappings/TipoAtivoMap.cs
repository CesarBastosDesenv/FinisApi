using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Mappings;

public class TipoAtivoMap : IEntityTypeConfiguration<TipoAtivo>
{
    public void Configure(EntityTypeBuilder<TipoAtivo> builder)
    {
        builder.ToTable("TipoAtivo");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.TipoNome)
        .IsRequired()
        .HasColumnType("varchar(50)");

        builder.Property(x => x.Status)
        .HasDefaultValue(true);

        builder.HasMany(x => x.Ativos)
        .WithOne(y => y.TipoAtivo)
        .HasForeignKey(x => x.Id);
       

       

    }
}
