using System;
using Finis.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Contex;

public class ApiContext : DbContext
{
 public ApiContext(DbContextOptions<ApiContext> options) : base(options)
  {

  }
  public DbSet<TipoAtivo> TipoAtivos { get; set; }
}
