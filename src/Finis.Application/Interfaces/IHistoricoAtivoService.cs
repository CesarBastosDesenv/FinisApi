using System;
using Finis.Application.Dto;
using Finis.Application.Dto.HistoricoAtivo;

namespace Finis.Application.Interfaces;

public interface IHistoricoAtivoService
{
    Task<ResultViewModel> AddAsync(HistoricoAtivoCadastro historicoativo);

    Task<ResultViewModel> UpdateAsync(HistoricoAtivoUpdate historicoativo);

    Task<ResultViewModel> BuscaHistoricoAtivoId(int Id);

    Task<ResultViewModel> DeletaHistoricoAtivoId(int Id);

}
