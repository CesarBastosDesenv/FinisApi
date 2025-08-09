using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.Rendimento;

public class RendimentoCadastro
{
 
    public int AtivoId { get; set; }
    //public int TipoId { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public string AnoRendimento { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public string MesRendimento { get; set; }
    public decimal QtdCotas { get; set; }
    public decimal ValorRendimento { get; set; }
    public decimal ValorRendimentoReais { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public string FlBolsa { get; set; }
   
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public string Corretora { get; set; }
    public DateOnly DtRendimento { get; set; }  
}
