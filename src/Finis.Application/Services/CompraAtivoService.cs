using System;
using Finis.Application.Dto;
using Finis.Application.Dto.CompraAtivo;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class CompraAtivoService : ICompraAtivoService
{
    private ICompraAtivoRepository _compraAtivoRepository;

    public CompraAtivoService(ICompraAtivoRepository compraAtivoRepository)
    {
        _compraAtivoRepository = compraAtivoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(CompraAtivoCadastro args)
    {
        var compraAtivo = new CompraAtivo()
        {
            AtivoId = args.AtivoId,
            NomeAtivo = args.NomeAtivo,
            DtCompra = args.DtCompra,
            ValorCompra = args.ValorCompra,
            EstimativaVenda = args.EstimativaVenda,
            ValorCota = args.ValorCota,
            QtdCotas = args.QtdCotas,
            FlVendido = args.FlVendido,
            FlBolsa = args.FlBolsa,
            Corretora = args.Corretora,
            Estrategia = args.Estrategia,
        };
        _compraAtivoRepository.AdicionarCompraAtivo(compraAtivo);
        var result = new ResultViewModel(await _compraAtivoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public Task<ResultViewModel> BuscaCompraAtivoId(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<ResultViewModel> DeletaCompraAtivoId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _compraAtivoRepository.BuscaCompraAtivo(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new CompraAtivoView() {
            Id = x.Id,
            AtivoId = x.AtivoId,
            NomeAtivo = x.NomeAtivo,
            DtCompra = x.DtCompra,
            ValorCompra = x.ValorCompra,
            EstimativaVenda = x.EstimativaVenda,
            ValorCota = x.ValorCota,
            QtdCotas = x.QtdCotas,
            FlVendido = x.FlVendido,
            FlBolsa = x.FlBolsa,
            Corretora = x.Corretora,
            Estrategia = x.Estrategia,
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public async Task<PagedList> GetListId(int pageNumber, int pageSize, int Id)
    {
        var retorno = await _compraAtivoRepository.BuscaCompraAtivoPorIdParams(pageNumber, pageSize, Id);
        var retornoModel = retorno.Select(x => new CompraAtivoView()
        {
            Id = x.Id,
            AtivoId = x.AtivoId,
            NomeAtivo = x.NomeAtivo,
            DtCompra = x.DtCompra,
            ValorCompra = x.ValorCompra,
            EstimativaVenda = x.EstimativaVenda,
            ValorCota = x.ValorCota,
            QtdCotas = x.QtdCotas,
            FlVendido = x.FlVendido,
            FlBolsa = x.FlBolsa,
            Corretora = x.Corretora,
            Estrategia = x.Estrategia,
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }
    

    public Task<ResultViewModel> UpdateAsync(CompraAtivoUpdate CompraAtivo)
    {
        throw new NotImplementedException();
    }
}
