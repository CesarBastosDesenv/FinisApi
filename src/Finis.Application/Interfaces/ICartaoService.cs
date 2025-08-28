using System;
using Finis.Application.Dto;
using Finis.Application.Dto.Cartao;

namespace Finis.Application.Interfaces;

public interface ICartaoService
{
    Task<ResultViewModel> AddAsync(CartaoCadastro cartao);

    Task<ResultViewModel> UpdateAsync(CartaoUpdate Cartao);

    Task<PagedList> GetAllAsync(int pageNumber, int pageSize);

    Task<ResultViewModel> BuscaCartaoId(int Id);
    
}
