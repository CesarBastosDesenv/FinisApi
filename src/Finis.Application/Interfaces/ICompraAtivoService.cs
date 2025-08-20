using System;
using Finis.Application.Dto;
using Finis.Application.Dto.CompraAtivo;

namespace Finis.Application.Interfaces;

public interface ICompraAtivoService
{
    Task<ResultViewModel> AddAsync(CompraAtivoCadastro CompraAtivo);
    Task<PagedList> GetListId(int pageNumber, int pageSize, int Id);

    Task<ResultViewModel> UpdateAsync(CompraAtivoUpdate updateAtivo);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaCompraAtivoId(int Id);

    Task<ResultViewModel> DeletaCompraAtivoId(int Id);
}
