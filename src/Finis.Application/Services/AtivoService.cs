using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Ativo;
using Finis.Application.Interfaces;
using Finis.Domain.Models;
using Finis.Infra.Data.Interfaces;

namespace Finis.Application.Services;

public class AtivoService : IAtivoService
{
    private IAtivoRepository _ativoRepository;

    public AtivoService(IAtivoRepository ativoRepository)
    {
        _ativoRepository = ativoRepository;
       
    }

    public async Task<ResultViewModel> AddAsync(AtivoCadastro args)
    {
        var ativo = new Ativo()
        {
            NomeAtivo = args.NomeAtivo,
            NomeAtivoCompleto = args.NomeAtivoCompleto,
            SeguimentoAtivo = args.SeguimentoAtivo,
            QtdCotas = args.QtdCotas,
            FlVendido = args.FlVendido,
            DtCadastro = args.DtCadastro,
            Imagem = args.Imagem,
            TipoAtivoId = args.TipoAtivoId,
        };
      
        _ativoRepository.AdicionarAtivo(ativo);
        var result = new ResultViewModel(await _ativoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao cadastrar");

        return result; 
    }

    public async Task<ResultViewModel> BuscaAtivoId(int Id)
    {
       return new ResultViewModel(await _ativoRepository.BuscaAtivoId(Id));
    }

    public Task<ResultViewModel> DeletaAtivoId(int Id)
    {
        throw new NotImplementedException();
    }

    public async Task<PagedList> GetAllAsync(int pageNumber, int pageSize)
    {
        var retorno = await _ativoRepository.BuscaAtivo(pageNumber, pageSize);
        var retornoModel = retorno.Select(x => new AtivoView() {
            Id = x.Id,
            NomeAtivo = x.NomeAtivo,
            NomeAtivoCompleto = x.NomeAtivoCompleto,
            SeguimentoAtivo = x.SeguimentoAtivo,
            QtdCotas = x.QtdCotas,
            FlVendido = x.FlVendido,
            DtCadastro = x.DtCadastro,
            Imagem = x.Imagem,
            TipoAtivoId = x.TipoAtivoId,
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public async Task<PagedList> GetListId(int pageNumber, int pageSize, int TipoAtivoId)
    {
        var retorno = await _ativoRepository.BuscaAtivoPorTipo(pageNumber, pageSize, TipoAtivoId);
        var retornoModel = retorno.Select(x => new AtivoView() {
            Id = x.Id,
            NomeAtivo = x.NomeAtivo,
            NomeAtivoCompleto = x.NomeAtivoCompleto,
            SeguimentoAtivo = x.SeguimentoAtivo,
            QtdCotas = x.QtdCotas,
            FlVendido = x.FlVendido,
            DtCadastro = x.DtCadastro,
            Imagem = x.Imagem,
            TipoAtivoId = x.TipoAtivoId,
        });
        return new PagedList() { Data = retornoModel, TotalCount = retorno.TotalCount };
    }

    public async Task<ResultViewModel> UpdateAsync(AtivoUpdate args)
    {
       var ativo = new Ativo()
        {
            Id = args.Id,
            NomeAtivo = args.NomeAtivo,
            NomeAtivoCompleto = args.NomeAtivoCompleto,
            SeguimentoAtivo = args.SeguimentoAtivo,
            QtdCotas = args.QtdCotas,
            FlVendido = args.FlVendido,
            DtCadastro = args.DtCadastro,
            Imagem = args.Imagem,
            TipoAtivoId = args.TipoAtivoId,
        };
        _ativoRepository.AtualizarAtivo(ativo);
        var result = new ResultViewModel(await _ativoRepository.SaveChangesAsync());
       
        if (!(bool)result.Data)
            result.AddNotification("", "Erro ao atualizar");

        return result; 
    }
}
