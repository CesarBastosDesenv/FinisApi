using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Conta;

namespace Finis.Application.Interfaces;

public interface IContaService
{
    Task<ResultViewModel> AddAsync(ContaCadastro conta);

    Task<ResultViewModel> UpdateAsync(ContaUpdate conta);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaContaId(int Id);

    Task<ResultViewModel> DeletaContaId(int Id);
}
