using System;

namespace Finis.Application.Dto;

public class TipoAtivoView
{
    public int Id { get; set; }
    public required string TipoNome { get; set; }
    public bool Status { get; set; }
}
