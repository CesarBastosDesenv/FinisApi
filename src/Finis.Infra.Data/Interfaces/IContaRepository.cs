using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface IContaRepository
{
    Task<PagedList<Conta>> BuscaConta(int pageNumber, int pageSize);
    Task<Conta> BuscaContaId(int Id);
    void AdicionarConta(Conta conta);
    void AtualizarConta(Conta conta);
    void DeletarContaAsync(int Id);

    Task<bool> SaveChangesAsync();
}
