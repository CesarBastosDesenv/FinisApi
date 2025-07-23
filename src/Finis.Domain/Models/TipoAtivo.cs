using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finis.Domain.Models;

public class TipoAtivo
{
    public int Id { get; set; } [InverseProperty("TipoAtivo")]
    public required string TipoNome { get; set; }
    public bool Status { get; set; }

    public ICollection<Ativo> Ativos { get; set; }

  
}
