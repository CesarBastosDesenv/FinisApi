using System;
using Finis.Domain.Models;
using Finis.Domain.Pagination;

namespace Finis.Infra.Data.Interfaces;

public interface IVendaAtivoRepository
{
    Task<PagedList<VendaAtivo>> BuscaVendaAtivo(int pageNumber, int pageSize);
    Task<PagedList<VendaAtivo>> BuscaVendaAtivoPorTipo(int pageNumber, int pageSize, int TipoAtivoId);
    Task<VendaAtivo> BuscaVendaAtivoId(int Id);
    void AdicionarVendaAtivo(VendaAtivo vendaAtivo);
    void AtualizarVendaAtivo(VendaAtivo vendaAtivo);
    void DeletarVendaAtivo(int Id);

    Task<bool> SaveChangesAsync();
}
