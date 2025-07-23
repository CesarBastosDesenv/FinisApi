using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.Ativo;

public class AtivoCadastro
{

[Required(ErrorMessage = "{0}: É obrigatório")]
[StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
public required string NomeAtivo { get; set; }

[Required(ErrorMessage = "{0}: É obrigatório")]
[StringLength(255, ErrorMessage = "{0}: Maximo de 255 caracteres")]
public required string NomeAtivoCompleto { get; set; }

[Required(ErrorMessage = "{0}: É obrigatório")]
[StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
public required string SeguimentoAtivo { get; set; }
public required string QtdCotas { get; set; }
public bool FlVendido { get; set; }
public DateOnly DtCadastro { get; set; }
public string? Imagem { get; set; }
public int TipoAtivoId { get; set; }
}
