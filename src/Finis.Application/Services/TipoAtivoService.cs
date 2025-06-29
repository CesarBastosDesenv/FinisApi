using System;
using Finis.Application.Dto;
using Finis.Application.Dto.TipoAtivo;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class TipoAtivoService : ITipoAtivoService
{
private ITipoAtivo _tipoAtivo;

    public TipoAtivoService(ITipoAtivo tipoAtivo)
    {
        _tipoAtivo = tipoAtivo;
       
    }

    public async Task<ResultViewModel> AddAsync(TipoAtivoCadastro args)
    {
        var tipoAtivo = new TipoAtivo()
        {
            TipoNome = args.TipoNome,
            Status = args.Status,
        };
        _tipoAtivo.AdicionarTipoAtivo(tipoAtivo);
        var result = new ResultViewModel(await _tipoAtivo.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public async Task<ResultViewModel> BuscaTipoAtivoId(int Id)
    {
       return new ResultViewModel(await _tipoAtivo.BuscaTipoAtivoId(Id));
    }

    public Task<ResultViewModel> DeletaTipoAtivoId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _tipoAtivo.BuscaTipoAtivo(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new TipoAtivoView() {
            Id = x.Id,
            TipoNome = x.TipoNome,
            Status = x.Status
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public async Task<ResultViewModel> UpdateAsync(TipoAtivoUpdate args)
    {
        var tipoAtivo = new TipoAtivo()
        {
            Id = args.Id,
            TipoNome = args.TipoNome,
            Status = args.Status
        };
        _tipoAtivo.AtualizarTipoAtivo(tipoAtivo);
        var result = new ResultViewModel(await _tipoAtivo.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao atualizar");

        return result; 
    }
}
