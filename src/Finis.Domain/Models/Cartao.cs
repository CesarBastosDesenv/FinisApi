using System;

namespace Finis.Domain.Models;

public class Cartao
{
    public int Id { get; set; }
    public string NomeCartao { get; set; }
    public DateOnly DtCadastro { get; set; }
    public string InstituicaoBancaria { get; set; }
    public bool Ativo { get; set; }

}
