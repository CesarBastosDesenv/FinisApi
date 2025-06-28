using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Contex;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class TipoAtivoRepository : ITipoAtivo
{
    private readonly ApiContext _context;

         public TipoAtivoRepository(ApiContext context)
        {
            _context = context;
        }
    public void AdicionarTipoAtivo(TipoAtivo tipoAtivo)
    {
        _context.Add(tipoAtivo);
    }

    public void AtualizarTipoAtivo(TipoAtivo tipoAtivo)
    {
        _context.Update(tipoAtivo);
    }

    public async Task<PagedList<TipoAtivo>> BuscaTipoAtivo(int pageNumber, int pageSize)
    {
        var query = _context.TipoAtivos.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<TipoAtivo> BuscaTipoAtivoId(int Id)
    {
        return await _context.TipoAtivos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarTipoAtivo(int Id)
    {
        _context.Remove(Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
