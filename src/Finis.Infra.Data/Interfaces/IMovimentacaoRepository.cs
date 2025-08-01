using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface IMovimentacaoRepository
{
    Task<PagedList<Movimentacao>> BuscaMovimentacao(int pageNumber, int pageSize);
    Task<Movimentacao> BuscaMovimentacaoId(int Id);
    void AdicionarMovimentacao(Movimentacao movimentacao);
    void AtualizarMovimentacao(Movimentacao movimentacao);
    void DeletarMovimentacaoAsync(int Id);

    Task<bool> SaveChangesAsync();


}
