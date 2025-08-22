using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finis.Domain.Models;

public class CompraAtivo
{
    public int Id { get; set; }
    public int AtivoId { get; set; }
    public required string NomeAtivo { get; set; }
    public DateOnly DtCompra { get; set; }
    public decimal ValorCompra { get; set; }
    public decimal EstimativaVenda { get; set; }
    public decimal ValorCota { get; set; }
    public Decimal QtdCotas { get; set; }
    public bool FlVendido { get; set; }
    public required string FlBolsa { get; set; }
    public required string Corretora { get; set; }
    public required string Estrategia { get; set; }
    public Ativo Ativo { get; set; }    
    

}
