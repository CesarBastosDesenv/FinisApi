using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Rendimento;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class RendimentoService : IRendimentoService
{
    private IRendimentoRepository _rendimentoRepository;

    public RendimentoService(IRendimentoRepository rendimentoRepository)
    {
        _rendimentoRepository = rendimentoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(RendimentoCadastro args)
    {
        var rendimento = new Rendimento()
        {
            AtivoId = args.AtivoId,
            //TipoId = args.TipoId,
            AnoRendimento = args.AnoRendimento,
            MesRendimento = args.MesRendimento,
            Corretora = args.Corretora,
            QtdCotas = args.QtdCotas,
            ValorRendimento = args.ValorRendimento,
            ValorRendimentoReais = args.ValorRendimentoReais,
            FlBolsa = args.FlBolsa,
         
        };
        _rendimentoRepository.AdicionarRendimento(rendimento);
        var result = new ResultViewModel(await _rendimentoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    

    public async Task<ResultViewModel> BuscaRendimentoId(int Id)
    {
        return new ResultViewModel(await _rendimentoRepository.BuscaRendimentoId(Id));
    }

    public Task<ResultViewModel> DeletaRendimentoId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _rendimentoRepository.BuscaRendimento(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new RendimentoView() {
            Id = x.Id,
            AtivoId = x.AtivoId,
            AnoRendimento = x.AnoRendimento,
            MesRendimento = x.MesRendimento,
            QtdCotas = x.QtdCotas,
            Corretora = x.Corretora,
            ValorRendimento = x.ValorRendimento,
            ValorRendimentoReais = x.ValorRendimentoReais,
            FlBolsa = x.Corretora.ToLower() switch
            {
                "Avenue" => "EUA",
                "Binance" => "EUA",
                "Inter-EUA" => "EUA",
                "Inter-BRA" => "B3",
                "Rico" => "B3",
                "C6" => "B3",
                "Nubank" => "B3",
                _=> x.FlBolsa
             }
           
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public async Task<PagedList> GetListId(int pageNumber, int pageSize, int Id)
    {
        var retorno = await _rendimentoRepository.BuscaRendimentoPorIDParams(pageNumber, pageSize, Id);
        var retornoModel = retorno.Select(x => new RendimentoView()
        {
            Id = x.Id,
            AtivoId = x.AtivoId,
            AnoRendimento = x.AnoRendimento,
            MesRendimento = x.MesRendimento,
            QtdCotas = x.QtdCotas,
            Corretora = x.Corretora,
            ValorRendimento = x.ValorRendimento,
            ValorRendimentoReais = x.ValorRendimentoReais,
            FlBolsa = x.FlBolsa,
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public Task<ResultViewModel> UpdateAsync(RendimentoUpdate updateRendimento)
    {
        throw new NotImplementedException();
    }
}
