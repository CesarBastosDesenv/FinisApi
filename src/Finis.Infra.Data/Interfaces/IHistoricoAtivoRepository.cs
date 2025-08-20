using System;
using Finis.Domain.Models;

namespace Finis.Infra.Data.Interfaces;

public interface IHistoricoAtivoRepository
{
    Task<List<HistoricoAtivo>> BuscaHistoricoAtivoId(int Id);
    void AdicionarHistoricoAtivo(HistoricoAtivo historicoAtivo);
    void AtualizarHistoricoAtivo(HistoricoAtivo historicoAtivo);
    void DeletarHistoricoAtivo(int Id);
    Task<bool> SaveChangesAsync(); 
}
