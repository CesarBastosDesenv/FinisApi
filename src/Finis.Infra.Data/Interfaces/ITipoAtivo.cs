using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface ITipoAtivo
{
    Task<PagedList<TipoAtivo>> BuscaTipoAtivo(int pageNumber, int pageSize);
    Task<TipoAtivo> BuscaTipoAtivoId(int Id);
    void AdicionarTipoAtivo(TipoAtivo tipoAtivo);
    void AtualizarTipoAtivo(TipoAtivo tipoAtivo);
    void DeletarTipoAtivo(int Id);

    Task<bool> SaveChangesAsync();
}
