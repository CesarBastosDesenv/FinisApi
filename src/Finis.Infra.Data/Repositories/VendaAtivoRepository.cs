using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class VendaAtivoRepository : IVendaAtivoRepository
{
    private readonly ApiContext _context;

    public VendaAtivoRepository(ApiContext context)
    {
        _context = context;
    }

    public void AdicionarVendaAtivo(VendaAtivo vendaAtivo)
    {
        _context.Add(vendaAtivo);
    }

    public void AtualizarVendaAtivo(VendaAtivo vendaAtivo)
    {
        _context.Update(vendaAtivo);
    }

    public async Task<PagedList<VendaAtivo>> BuscaVendaAtivo(int pageNumber, int pageSize)
    {
        var query = _context.VendaAtivos.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<VendaAtivo> BuscaVendaAtivoId(int Id)
    {
        return await _context.VendaAtivos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public Task<PagedList<VendaAtivo>> BuscaVendaAtivoPorTipo(int pageNumber, int pageSize, int TipoAtivoId)
    {
        throw new NotImplementedException();
    }

    public void DeletarVendaAtivo(int Id)
    {
        _context.Remove(Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
