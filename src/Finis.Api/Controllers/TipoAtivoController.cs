using System;
using Finis.Api.Models;
using Finis.Application.Dto;
using Finis.Application.Dto.TipoAtivo;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Finis.Api.Extensions;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoAtivoController : ControllerBase
{
    private ILogger<TipoAtivoController> _logger;
    private ITipoAtivoService _tipoAtivoService;

    public TipoAtivoController(ILogger<TipoAtivoController> logger, ITipoAtivoService tipoAtivoService)
    {
        _logger = logger;
        _tipoAtivoService = tipoAtivoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams paginationParams)
    {
        try
        {
            var result = await _tipoAtivoService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
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
            var result = await _tipoAtivoService.BuscaTipoAtivoId(Id);
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
    public async Task<ActionResult> Add(TipoAtivoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _tipoAtivoService.AddAsync(args);
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
    public async Task<ActionResult> Update(TipoAtivoUpdate args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _tipoAtivoService.UpdateAsync(args);
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
