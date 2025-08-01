using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class MovimentacaoRepository : IMovimentacaoRepository
{
     private readonly ApiContext _context;

         public MovimentacaoRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarMovimentacao(Movimentacao movimentacao)
    {
        _context.Add(movimentacao);
    }

    public void AtualizarMovimentacao(Movimentacao movimentacao)
    {
        _context.Update(movimentacao);
    }

    public async Task<PagedList<Movimentacao>> BuscaMovimentacao(int pageNumber, int pageSize)
    {
        var query = _context.Movimentacaoes.AsQueryable();
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<Movimentacao> BuscaMovimentacaoId(int Id)
    {
         return await _context.Movimentacaoes.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public void DeletarMovimentacaoAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
