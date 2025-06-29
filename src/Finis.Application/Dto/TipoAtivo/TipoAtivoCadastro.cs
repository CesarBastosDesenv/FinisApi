using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto;

public class TipoAtivoCadastro
{
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public required string TipoNome { get; set; }
    
    public bool Status { get; set; }
}
