using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Cartao;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class CartaoService : ICartaoService
{
    private ICartaoRepository _cartaoRepository;

    public CartaoService(ICartaoRepository cartaoRepository)
    {
        _cartaoRepository = cartaoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(CartaoCadastro args)
    {
         var cartao = new Cartao()
        {
            NomeCartao = args.NomeCartao,
            DtCadastro = args.DtCadastro,
            InstituicaoBancaria = args.InstituicaoBancaria,
            Ativo = args.Ativo,
        };
        _cartaoRepository.AdicionarCartao(cartao);
        var result = new ResultViewModel(await _cartaoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public async Task<ResultViewModel> BuscaCartaoId(int Id)
    {
        return new ResultViewModel(await _cartaoRepository.BuscaCartaoPorId(Id));
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _cartaoRepository.BuscaCartaoParam(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new CartaoView()
        {
            Id = x.Id,
            NomeCartao = x.NomeCartao,
            DtCadastro = x.DtCadastro,
            InstituicaoBancaria = x.InstituicaoBancaria,
            Ativo = x.Ativo,
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public Task<ResultViewModel> UpdateAsync(CartaoUpdate Cartao)
    {
        throw new NotImplementedException();
    }
}
