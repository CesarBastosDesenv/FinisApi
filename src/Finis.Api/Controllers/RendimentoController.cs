using System;
using Finis.Api.Extensions;
using Finis.Api.Models;
using Finis.Application.Dto;
using Finis.Application.Dto.Rendimento;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RendimentoController : ControllerBase
{

    private ILogger<RendimentoController> _logger;
    private IRendimentoService _rendimentoService;

    public RendimentoController(ILogger<RendimentoController> logger, IRendimentoService rendimentoService)
    {
        _logger = logger;
        _rendimentoService = rendimentoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams paginationParams)
    {
        try
        {
            var result = await _rendimentoService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
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
            var result = await _rendimentoService.BuscaRendimentoId(Id);
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
    public async Task<ActionResult> Add(RendimentoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _rendimentoService.AddAsync(args);
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
