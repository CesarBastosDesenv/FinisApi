using System;
using System.Security.Cryptography;

namespace Finis.Domain.Models;

public class Ativo
{
    public int Id { get; set; }
    public TipoAtivo? TipoAtivo { get; set; }
    public required string NomeAtivo { get; set; }
    public required string NomeAtivoCompleto { get; set; }
    public required string SeguimentoAtivo { get; set; }
    public required decimal QtdCotas { get; set; }
    public bool FlVendido { get; set; }
    public DateOnly DtCadastro { get; set; }
    public string? Imagem { get; set; }
    public int TipoAtivoId { get; set; }
    public ICollection<CompraAtivo> CompraAtivos { get; set; }
    public ICollection<Rendimento> Rendimentos { get; set; }
    public ICollection<HistoricoAtivo> HistoricoAtivos { get; set; }

}
