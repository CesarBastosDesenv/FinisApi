using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface IAtivoRepository
{
    Task<PagedList<Ativo>> BuscaAtivo(int pageNumber, int pageSize);
    Task<PagedList<Ativo>> BuscaAtivoPorTipo(int pageNumber, int pageSize, int TipoAtivoId);
    Task<List<Ativo>> BuscaAtivoSemParam();
    Task<Ativo> BuscaAtivoId(int Id);
    void AdicionarAtivo(Ativo ativo);
    void AtualizarAtivo(Ativo ativo);
    void DeletarAtivo(int Id);

    Task<bool> SaveChangesAsync();

}
