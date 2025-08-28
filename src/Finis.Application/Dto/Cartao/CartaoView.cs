using System;

namespace Finis.Application.Dto.Cartao;

public class CartaoView
{
    public int Id { get; set; }
    public string NomeCartao { get; set; }
    public DateOnly DtCadastro { get; set; }
    public string InstituicaoBancaria { get; set; }
    public bool Ativo { get; set; }
}
