using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Context;

public class ApiContext : DbContext
{
  public ApiContext(DbContextOptions<ApiContext> options) : base(options)
  {

  }
  public DbSet<TipoAtivo> TipoAtivos { get; set; }
  public DbSet<Ativo> Ativos { get; set; }
  public DbSet<CompraAtivo> CompraAtivos { get; set; }

   public DbSet<Conta> Contas { get; set; }
}
