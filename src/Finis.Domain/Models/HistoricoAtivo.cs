using System;

namespace Finis.Domain.Models;

public class HistoricoAtivo
{
    public int Id { get; set; }
    public DateOnly DtHistorico { get; set; }
    public string Descricao { get; set; }
    public int AtivoId { get; set; }
    public Ativo Ativo { get; set; } 
}
