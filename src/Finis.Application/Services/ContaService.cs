using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Conta;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class ContaService : IContaService
{
    private IContaRepository _contaRepository;

    public ContaService(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(ContaCadastro args)
    {
         var conta = new Conta()
        {
            NomeConta = args.NomeConta,
            ContaPaiId = args.ContaPaiId,
            ValorSaldo = args.ValorSaldo,
            DataCriacao = args.DataCriacao,
            Instituicao = args.Instituicao,
            Status = args.Status,
           
        };
      
        _contaRepository.AdicionarConta(conta);
        var result = new ResultViewModel(await _contaRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public async Task<ResultViewModel> BuscaContaId(int Id)
    {
        return new ResultViewModel(await _contaRepository.BuscaContaId(Id));
    }

    public Task<ResultViewModel> DeletaContaId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _contaRepository.BuscaConta(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new ContaView() {
            Id = x.Id,
            NomeConta = x.NomeConta,
            ContaPaiId = x.ContaPaiId,
            ValorSaldo = x.ValorSaldo,
            DataCriacao = x.DataCriacao,
            Instituicao = x.Instituicao,
            Status = x.Status,
           
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public Task<ResultViewModel> UpdateAsync(ContaUpdate conta)
    {
        throw new NotImplementedException();
    }
}
