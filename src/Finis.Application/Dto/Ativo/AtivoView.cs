using System;

namespace Finis.Application.Dto.Ativo;

public class AtivoView
{
public int Id { get; set; }

public required string NomeAtivo { get; set; }
public required string NomeAtivoCompleto { get; set; }
public required string SeguimentoAtivo { get; set; }
public required string QtdCotas { get; set; }
public bool FlVendido { get; set; }
public DateOnly DtCadastro { get; set; }
public string? Imagem { get; set; }
public int TipoAtivoId { get; set; }
}
