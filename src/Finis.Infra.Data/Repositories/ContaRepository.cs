using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class ContaRepository : IContaRepository
{
    private readonly ApiContext _context;

         public ContaRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarConta(Conta conta)
    {
        _context.Add(conta);
    }

    public void AtualizarConta(Conta conta)
    {
        _context.Update(conta);
    }

    public async Task<PagedList<Conta>> BuscaConta(int pageNumber, int pageSize)
    {
         var query = _context.Contas.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Conta> BuscaContaId(int Id)
    {
        return await _context.Contas.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarContaAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
