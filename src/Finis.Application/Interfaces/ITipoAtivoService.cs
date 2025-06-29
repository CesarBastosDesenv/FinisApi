using System;
using Finis.Application.Dto;
using Finis.Application.Dto.TipoAtivo;

namespace Finis.Application.Interfaces;

public interface ITipoAtivoService
{
    Task<ResultViewModel> AddAsync(TipoAtivoCadastro tipoAtivo);

    Task<ResultViewModel> UpdateAsync(TipoAtivoUpdate tipoAtivo);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaTipoAtivoId(int Id);

    Task<ResultViewModel> DeletaTipoAtivoId(int Id);
}
