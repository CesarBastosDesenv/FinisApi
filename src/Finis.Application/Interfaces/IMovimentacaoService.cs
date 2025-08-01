using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Movimentacao;
using Finis.Domain.Models;

namespace Finis.Application.Interfaces;

public interface IMovimentacaoService
{
    Task<ResultViewModel> AddAsync(MovimentacaoCadastro Movimentacao);

    Task<ResultViewModel> UpdateAsync(MovimentacaoUpdate updateAtivo);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaMovimentacaoId(int Id);

    Task<ResultViewModel> DeletaMovimentacaoId(int Id);
}
