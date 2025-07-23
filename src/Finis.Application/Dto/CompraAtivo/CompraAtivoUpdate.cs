using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.CompraAtivo;

public class CompraAtivoUpdate
{
public int AtivoId { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public required string NomeAtivo { get; set; }
    public DateOnly DtCompra { get; set; }
    public decimal ValorCompra { get; set; }
    public decimal EstimativaVenda { get; set; }
    public decimal ValorCota { get; set; }
    public int QtdCotas { get; set; }
    public bool FlVendido { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public required string FlBolsa { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")] 
    public required string Corretora { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public required string Estrategia { get; set; }
}
