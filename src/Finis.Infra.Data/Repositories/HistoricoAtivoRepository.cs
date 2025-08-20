using System;
using Finis.Domain.Models;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class HistoricoAtivoRepository : IHistoricoAtivoRepository
{
    private readonly ApiContext _context;

    public HistoricoAtivoRepository(ApiContext context)
    {
        _context = context;
    }

    public void AdicionarHistoricoAtivo(HistoricoAtivo historicoAtivo)
    {
        _context.Add(historicoAtivo);
    }

    public void AtualizarHistoricoAtivo(HistoricoAtivo historicoAtivo)
    {
         _context.Update(historicoAtivo);
    }

    public async Task<List<HistoricoAtivo>> BuscaHistoricoAtivoId(int Id)
    {
        return await _context.HistoricoAtivos.
                       Where(x => x.AtivoId == Id).ToListAsync();
    }

    public void DeletarHistoricoAtivo(int Id)
    {
        _context.Remove(Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
