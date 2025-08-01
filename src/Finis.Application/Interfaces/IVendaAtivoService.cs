using System;
using Finis.Application.Dto;
using Finis.Application.Dto.VendaAtivo;
using Finis.Domain.Models;

namespace Finis.Application.Interfaces;

public interface IVendaAtivoService
{
    Task<ResultViewModel> AddAsync(VendaAtivoCadastro vendaAtivo);

    Task<ResultViewModel> UpdateAsync(VendaAtivoUpdate vendaAtivoUpdate);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaVendaAtivoId(int Id);

    Task<ResultViewModel> DeletaVendaAtivoId(int Id);
}
