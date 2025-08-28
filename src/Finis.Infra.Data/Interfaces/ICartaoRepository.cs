using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface ICartaoRepository
{
    Task<PagedList<Cartao>> BuscaCartaoParam(int pageNumber, int pageSize);
    Task<Cartao> BuscaCartaoPorId(int Id);
    void AdicionarCartao(Cartao cartao);
    void AtualizarCartao(Cartao cartao);

    Task<bool> SaveChangesAsync();
 
}
