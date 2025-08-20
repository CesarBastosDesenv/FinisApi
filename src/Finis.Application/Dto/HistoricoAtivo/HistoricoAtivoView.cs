using System;

namespace Finis.Application.Dto.HistoricoAtivo;

public class HistoricoAtivoView
{
    public int Id { get; set; }
    public DateOnly DtHistorico { get; set; }
    public string Descricao { get; set; }
    public int AtivoId { get; set; }
  
}
