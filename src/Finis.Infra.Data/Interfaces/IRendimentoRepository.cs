using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface IRendimentoRepository
{
    Task<PagedList<Rendimento>> BuscaRendimento(int pageNumber, int pageSize);
    Task<Rendimento> BuscaRendimentoId(int Id);
    void AdicionarRendimento(Rendimento rendimento);
    void AtualizarRendimento(Rendimento rendimento);
    void DeletarRendimento(int Id);

    Task<bool> SaveChangesAsync();
}
