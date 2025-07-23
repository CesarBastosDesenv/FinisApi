using System;
using Finis.Api.Extensions;
using Finis.Api.Models;
using Finis.Application.Dto;
using Finis.Application.Dto.CompraAtivo;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompraAtivoController : ControllerBase
{
    private ILogger<CompraAtivoController> _logger;
    private ICompraAtivoService _compraAtivoService;

    public CompraAtivoController(ILogger<CompraAtivoController> logger, ICompraAtivoService compraAtivoService)
    {
        _logger = logger;
        _compraAtivoService = compraAtivoService;
    }

 [HttpGet]
    public async Task<ActionResult> Get([FromQuery] PaginationParams paginationParams)
    {
        try
        {
            var result = await _compraAtivoService.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
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
            var result = await _compraAtivoService.BuscaCompraAtivoId(Id);
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
    public async Task<ActionResult> Add(CompraAtivoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _compraAtivoService.AddAsync(args);
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
    public async Task<ActionResult> Update(CompraAtivoUpdate args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _compraAtivoService.UpdateAsync(args);
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
