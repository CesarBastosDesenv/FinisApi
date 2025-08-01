using System;

namespace Finis.Application.Dto.VendaAtivo;

public class VendaAtivoUpdate
{
    public int Id { get; set; }
    public int CompraId { get; set; }
    public int AtivoId { get; set; }
    public decimal QtdCotas { get; set; }
    public DateOnly DtVenda { get; set; }
    public decimal ValorVenda { get; set; }
    public decimal TotalTaxas { get; set; }
    public decimal ValorLucro { get; set; }
    public decimal ValorLucroReais { get; set; }
    public decimal ValorRecebido { get; set; }
    public string FlBolsa { get; set; }   
}
