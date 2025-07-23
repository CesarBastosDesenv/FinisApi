using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class CompraAtivoRepository : ICompraAtivoRepository
{
    private readonly ApiContext _context;

         public CompraAtivoRepository(ApiContext context)
        {
            _context = context;
        }
    public void AdicionarCompraAtivo(CompraAtivo compraAtivo)
    {
        _context.Add(compraAtivo);
    }

    public void AtualizarCompraAtivo(CompraAtivo compraAtivo)
    {
        _context.Update(compraAtivo);
    }

    public async Task<PagedList<CompraAtivo>> BuscaCompraAtivo(int pageNumber, int pageSize)
    {
        var query = _context.CompraAtivos.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<CompraAtivo> BuscaCompraAtivoId(int Id)
    {
        return await _context.CompraAtivos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarCompraAtivo(int Id)
    {
        _context.Remove(Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
