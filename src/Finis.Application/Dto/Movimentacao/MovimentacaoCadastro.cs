using System;
using System.ComponentModel.DataAnnotations;

namespace Finis.Application.Dto.Movimentacao;

public class MovimentacaoCadastro
{
    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(50, ErrorMessage = "{0}: Maximo de 50 caracteres")]   
    public string TipoGasto { get; set; }
    public DateOnly DtMovimentacao { get; set; }
    public int FlMovimentacao { get; set; }
    public int ContaId { get; set; }

    [Required(ErrorMessage = "{0}: É obrigatório")]
    [StringLength(255, ErrorMessage = "{0}: Maximo de 255 caracteres")]
    public string DescricaoMovimentacao { get; set; }
    public decimal ValorMovimentacao { get; set; }
}
