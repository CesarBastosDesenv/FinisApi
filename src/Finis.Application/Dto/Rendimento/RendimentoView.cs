using System;

namespace Finis.Application.Dto.Rendimento;

public class RendimentoView
{
    public int Id { get; set; }
    public int AtivoId { get; set; }
   // public int TipoId { get; set; }
    public string AnoRendimento { get; set; }
    public string MesRendimento { get; set; }
    public decimal QtdCotas { get; set; }
    public decimal ValorRendimento { get; set; }
    public decimal ValorRendimentoReais { get; set; }
    public string FlBolsa { get; set; }
    public string Corretora { get; set; }
    public DateOnly DtRendimento { get; set; }  
}
