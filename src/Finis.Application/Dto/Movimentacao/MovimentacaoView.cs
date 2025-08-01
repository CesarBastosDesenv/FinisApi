using System;

namespace Finis.Application.Dto.Movimentacao;

public class MovimentacaoView
{
    public int Id { get; set; }
    public string TipoGasto { get; set; }
    public DateOnly DtMovimentacao { get; set; }
    public int FlMovimentacao { get; set; }
    public int ContaId { get; set; }
    public string DescricaoMovimentacao { get; set; }
    public decimal ValorMovimentacao { get; set; }

}
