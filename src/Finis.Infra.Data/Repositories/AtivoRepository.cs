using System;
using System.Security.Cryptography.X509Certificates;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class AtivoRepository : IAtivoRepository
{
    private readonly ApiContext _context;

         public AtivoRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarAtivo(Ativo ativo)
    {
        _context.Add(ativo);
    }

    public void AtualizarAtivo(Ativo ativo)
    {
        _context.Update(ativo);
    }

    public async Task<PagedList<Ativo>> BuscaAtivo(int pageNumber, int pageSize)
    {
       var query = _context.Ativos.Where(Ca => Ca.FlVendido.Equals(false))      
                                  .OrderByDescending(x => x.TipoAtivoId)
                                  ;
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Ativo> BuscaAtivoId(int Id)
    {
         return await _context.Ativos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<PagedList<Ativo>> BuscaAtivoPorTipo(int pageNumber, int pageSize, int TipoAtivoId)
    {
        var query = _context.Ativos.AsQueryable();
        query = query.Where(x => x.TipoAtivoId == TipoAtivoId);
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public void DeletarAtivo(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
