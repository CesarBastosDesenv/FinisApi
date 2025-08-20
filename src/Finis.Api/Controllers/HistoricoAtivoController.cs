using System;
using Finis.Application.Dto;
using Finis.Application.Dto.HistoricoAtivo;
using Finis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finis.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistoricoAtivoController : ControllerBase
{
    private ILogger<HistoricoAtivoController> _logger;
    private IHistoricoAtivoService _historicoAtivoService;
    public HistoricoAtivoController(ILogger<HistoricoAtivoController> logger, IHistoricoAtivoService historicoAtivoService)
    {
        _logger = logger;
        _historicoAtivoService = historicoAtivoService;
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult> Get(int Id)
    {
        try
        {
            var result = await _historicoAtivoService.BuscaHistoricoAtivoId(Id);
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
    public async Task<ActionResult> Add(HistoricoAtivoCadastro args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _historicoAtivoService.AddAsync(args);
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
    public async Task<ActionResult> Update(HistoricoAtivoUpdate args)
    {
        try
        {
            if (!ModelState.IsValid) return Ok(new ResultViewModel(args, ModelState));
            var result = await _historicoAtivoService.UpdateAsync(args);
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
