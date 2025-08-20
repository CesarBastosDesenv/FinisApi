using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Rendimento;

namespace Finis.Application.Interfaces;

public interface IRendimentoService
{
    Task<ResultViewModel> AddAsync(RendimentoCadastro CompraRendimento);
    Task<PagedList> GetListId(int pageNumber, int pageSize, int Id);

    Task<ResultViewModel> UpdateAsync(RendimentoUpdate updateRendimento);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaRendimentoId(int Id);

    Task<ResultViewModel> DeletaRendimentoId(int Id);
}
