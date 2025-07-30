using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.Conta;

public class ContaUpdate
{
    public int Id { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public string NomeConta { get; set; }
    public int ContaPaiId { get; set; }
    public decimal ValorSaldo { get; set; }
    public DateOnly DataCriacao { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]   
    public string Instituicao { get; set; } 
    public bool Status { get; set; }
}
