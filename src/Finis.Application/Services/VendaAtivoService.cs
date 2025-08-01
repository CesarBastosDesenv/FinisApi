using System;
using Finis.Application.Dto;
using Finis.Application.Dto.VendaAtivo;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class VendaAtivoService : IVendaAtivoService
{

    private IVendaAtivoRepository _vendaAtivoRepository;

    public VendaAtivoService(IVendaAtivoRepository vendaAtivoRepository)
    {
        _vendaAtivoRepository = vendaAtivoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(VendaAtivoCadastro args)
    {
         var vendaAtivo = new VendaAtivo()
        {
            CompraId = args.CompraId,
            AtivoId = args.AtivoId,
            QtdCotas = args.QtdCotas,
            DtVenda = args.DtVenda,
            ValorVenda = args.ValorVenda,
            TotalTaxas = args.TotalTaxas,
            ValorLucro = args.ValorLucro,
            ValorLucroReais = args.ValorLucroReais,
            ValorRecebido = args.ValorRecebido,
            FlBolsa = args.FlBolsa,
           
        };
      
        _vendaAtivoRepository.AdicionarVendaAtivo(vendaAtivo);
        var result = new ResultViewModel(await _vendaAtivoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public async Task<ResultViewModel> BuscaVendaAtivoId(int Id)
    {
        return new ResultViewModel(await _vendaAtivoRepository.BuscaVendaAtivoId(Id));
    }

    public Task<ResultViewModel> DeletaVendaAtivoId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _vendaAtivoRepository.BuscaVendaAtivo(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new VendaAtivoView()
        {
            Id = x.Id,
            CompraId = x.CompraId,
            AtivoId = x.AtivoId,
            QtdCotas = x.QtdCotas,
            DtVenda = x.DtVenda,
            ValorVenda = x.ValorVenda,
            TotalTaxas = x.TotalTaxas,
            ValorLucro = x.ValorLucro,
            ValorLucroReais = x.ValorLucroReais,
            ValorRecebido = x.ValorRecebido,
            FlBolsa = x.FlBolsa,
           
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public Task<ResultViewModel> UpdateAsync(VendaAtivoUpdate vendaAtivoUpdate)
    {
        throw new NotImplementedException();
    }
}
