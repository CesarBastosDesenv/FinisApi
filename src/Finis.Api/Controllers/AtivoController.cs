using System;
using Finis.Api.Extensions;
using Finis.Api.Models;
using Finis.Application.Dto;
using Finis.Application.Dto.Ativo;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AtivoController : ControllerBase
{
    private ILogger<AtivoController> _logger;
    private IAtivoService _ativoService;

    public AtivoController(ILogger<AtivoController> logger, IAtivoService ativoService)
    {
        _logger = logger;
        _ativoService = ativoService;
    }

    [HttpGet]    
    public async Task<ActionResult> Get()
    {
        try
        {
            var result = await _ativoService.GetAtivos();
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult> GetAll([FromQuery] PaginationParams paginationParams)
    {
        try
        {
            var result = await _ativoService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
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
            var result = await _ativoService.BuscaAtivoId(Id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            var er = new ResultViewModel();
            er.AddNotification("Erro", ex.Message);
            return BadRequest(er);
        }
    }

    [HttpGet("{Id}/list")]
    public async Task<ActionResult> GetListId([FromQuery]PaginationParams paginationParams, int Id)
    {
        try
        {
            var result = await _ativoService.GetListId(paginationParams.PageNumber, paginationParams.PageSize, Id);
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

    [HttpPost]
    public async Task<ActionResult> Add(AtivoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _ativoService.AddAsync(args);
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
    public async Task<ActionResult> Update(AtivoUpdate args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _ativoService.UpdateAsync(args);
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
