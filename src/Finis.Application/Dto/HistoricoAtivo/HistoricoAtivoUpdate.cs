using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.HistoricoAtivo;

public class HistoricoAtivoUpdate
{
   
    public int Id { get; set; }
    
    public DateOnly DtHistorico { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]
    public string Descricao { get; set; }

    public int AtivoId { get; set; }
  
}
