using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Ativo;
using Finis.Domain.Models;

namespace Finis.Application.Interfaces;

public interface IAtivoService
{
    Task<ResultViewModel> AddAsync(AtivoCadastro ativo);

    Task<ResultViewModel> UpdateAsync(AtivoUpdate ativo);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<PagedList> GetListId(int pageNumber, int pageSize, int TipoAtivoId);
    Task<List<Ativo>> GetAtivos();

    Task<ResultViewModel> BuscaAtivoId(int Id);

    Task<ResultViewModel> DeletaAtivoId(int Id);

}
