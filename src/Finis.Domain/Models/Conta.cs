using System;

namespace Finis.Domain.Models;

public class Conta
{
    public int Id { get; set; }
    public string NomeConta { get; set; }
    public int ContaPaiId { get; set; }
    public decimal ValorSaldo { get; set; }
    public DateOnly DataCriacao { get; set; }
    public string Instituicao { get; set; } 
    public bool Status { get; set; }
   
}
