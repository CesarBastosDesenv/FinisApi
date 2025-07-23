using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface ICompraAtivoRepository
{
 Task<PagedList<CompraAtivo>> BuscaCompraAtivo(int pageNumber, int pageSize);
    Task<CompraAtivo> BuscaCompraAtivoId(int Id);
    void AdicionarCompraAtivo(CompraAtivo compraAtivo);
    void AtualizarCompraAtivo(CompraAtivo compraAtivo);
    void DeletarCompraAtivo(int Id);

    Task<bool> SaveChangesAsync();
}
