using System;
using Finis.Api.Extensions;
using Finis.Api.Models;
using Finis.Application.Dto;
using Finis.Application.Dto.VendaAtivo;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VendaAtivoController : ControllerBase
{
    private ILogger<VendaAtivoController> _logger;
    private IVendaAtivoService _vendaAtivoService;

    public VendaAtivoController(ILogger<VendaAtivoController> logger, IVendaAtivoService vendaAtivoService)
    {
        _logger = logger;
        _vendaAtivoService = vendaAtivoService;
    }

    [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams paginationParams)
    {
        try
        {
            var result = await _vendaAtivoService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
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
            var result = await _vendaAtivoService.BuscaVendaAtivoId(Id);
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
    public async Task<ActionResult> Add(VendaAtivoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _vendaAtivoService.AddAsync(args);
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
    public async Task<ActionResult> Update(VendaAtivoUpdate args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _vendaAtivoService.UpdateAsync(args);
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
