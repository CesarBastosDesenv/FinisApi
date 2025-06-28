using System;

namespace Finis.Domain.Models;

public class TipoAtivo
{
public int Id { get; set; }
public required string TipoNome { get; set; }    
public bool Status { get; set; }    
}
