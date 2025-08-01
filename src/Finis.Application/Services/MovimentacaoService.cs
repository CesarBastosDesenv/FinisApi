using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Movimentacao;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;
using Finis.Infra.Data.Repositories;

namespace Finis.Application.Services;

public class MovimentacaoService : IMovimentacaoService
{

    private IMovimentacaoRepository _movimentacaoRepository;

    public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)
    {
        _movimentacaoRepository = movimentacaoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(MovimentacaoCadastro args)
    {
        var movimentacao = new Movimentacao()
        {
            TipoGasto = args.TipoGasto,
            DtMovimentacao = args.DtMovimentacao,
            FlMovimentacao = args.FlMovimentacao,
            ContaId = args.ContaId,
            DescricaoMovimentacao = args.DescricaoMovimentacao,
            ValorMovimentacao = args.ValorMovimentacao,
            
        };
        _movimentacaoRepository.AdicionarMovimentacao(movimentacao);
        var result = new ResultViewModel(await _movimentacaoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public Task<ResultViewModel> BuscaMovimentacaoId(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultViewModel> DeletaMovimentacaoId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
         var retorno = await _movimentacaoRepository.BuscaMovimentacao(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new MovimentacaoView() {
            Id = x.Id,
            TipoGasto = x.TipoGasto,
            DtMovimentacao = x.DtMovimentacao,
            FlMovimentacao = x.FlMovimentacao,
            ContaId = x.ContaId,
            DescricaoMovimentacao = x.DescricaoMovimentacao,
            ValorMovimentacao = x.ValorMovimentacao,
            
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public Task<ResultViewModel> UpdateAsync(MovimentacaoUpdate updateAtivo)
    {
        throw new NotImplementedException();
    }
}
