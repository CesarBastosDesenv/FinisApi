using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;
using Finis.Infra.Data.Context;
using Finis.Infra.Data.Helpers;
using Finis.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finis.Infra.Data.Repositories;

public class CartaoRepository : ICartaoRepository
{
    private readonly ApiContext _context;

         public CartaoRepository(ApiContext context)
        {
            _context = context;
        }

    public void AdicionarCartao(Cartao cartao)
    {
        _context.Add(cartao);
    }

    public void AtualizarCartao(Cartao cartao)
    {
        _context.Update(cartao);
    }

    public async Task<Cartao> BuscaCartaoPorId(int Id)
    {
        return await _context.Cartoes.
                       Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<PagedList<Cartao>> BuscaCartaoParam(int pageNumber, int pageSize)
    {
        var query = _context.Cartoes.Where(Ca => Ca.Ativo.Equals(true));    
                                                
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
