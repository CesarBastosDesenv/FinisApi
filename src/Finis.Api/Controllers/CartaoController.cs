using System;
using Finis.Api.Extensions;
using Finis.Api.Models;
using Finis.Application.Dto;
using Finis.Application.Dto.Cartao;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartaoController : ControllerBase
{
    private ILogger<CartaoController> _logger;
    private ICartaoService _cartaoService;

    public CartaoController(ILogger<CartaoController> logger, ICartaoService cartaoService)
    {
        _logger = logger;
        _cartaoService = cartaoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams paginationParams)
    {
        try
        {
            var result = await _cartaoService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages));
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult> Get(int Id)
    {
        try
        {
            var result = await _cartaoService.BuscaCartaoId(Id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

[HttpPost]
    public async Task<ActionResult> Add(CartaoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _cartaoService.AddAsync(args);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

    [HttpPut]
    public async Task<ActionResult> Update(CartaoUpdate args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _cartaoService.UpdateAsync(args);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

}
