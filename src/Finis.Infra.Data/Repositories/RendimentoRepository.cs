using System;
using Azure.Core.Pipeline;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class RendimentoRepository : IRendimentoRepository
{
        private readonly ApiContext _context;

         public RendimentoRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarRendimento(Rendimento rendimento)
    {
        _context.Add(rendimento);
    }

    public void AtualizarRendimento(Rendimento rendimento)
    {
        _context.Update(rendimento);
    }

    public async Task<PagedList<Rendimento>> BuscaRendimento(int pageNumber, int pageSize)
    {
        var query = _context.Rendimentos.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Rendimento> BuscaRendimentoId(int Id)
    {
        return await _context.Rendimentos.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarRendimento(int Id)
    {
        _context.Remove(Id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
