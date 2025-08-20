using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.HistoricoAtivo;

public class HistoricoAtivoCadastro
{

    public DateOnly DtHistorico { get; set; }
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(255, ErrorMessage = "{0}: Maximo de 255 caracteres")]
    public string Descricao { get; set; }
    public int AtivoId { get; set; }
  
}
