using System;
using Finis.Application.Dto;
using Finis.Application.Dto.HistoricoAtivo;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;
using Finis.Infra.Data.Repositories;

namespace Finis.Application.Services;

public class HistoricoAtivoService : IHistoricoAtivoService
{
     private IHistoricoAtivoRepository _historicoAtivoRepository;

    public HistoricoAtivoService(IHistoricoAtivoRepository historicoAtivoRepository)
    {
        _historicoAtivoRepository = historicoAtivoRepository;
       
    }
    public async Task<ResultViewModel> AddAsync(HistoricoAtivoCadastro args)
    {
        var historicoAtivo = new HistoricoAtivo()
        {
            DtHistorico = args.DtHistorico,
            Descricao = args.Descricao,
            AtivoId = args.AtivoId,

        };

        _historicoAtivoRepository.AdicionarHistoricoAtivo(historicoAtivo);
        var result = new ResultViewModel(await _historicoAtivoRepository.SaveChangesAsync());

        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result;
    }

    public async Task<ResultViewModel> BuscaHistoricoAtivoId(int Id)
    {
        return new ResultViewModel(await _historicoAtivoRepository.BuscaHistoricoAtivoId(Id));
    }

    public Task<ResultViewModel> DeletaHistoricoAtivoId(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultViewModel> UpdateAsync(HistoricoAtivoUpdate historicoativo)
    {
        throw new NotImplementedException();
    }
}
