﻿using Microsoft.AspNetCore.Mvc;
using BoleteriaOnline.Web.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Web.Controllers;
/*
[Route("api/[controller]")]
[ApiController]
public class PaisesController : ControllerBase
{
    private readonly IParadaService _paradaService;

    public PaisesController(IParadaService service)
    {
        _paradaService = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ICollection<ParadaDTO>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ParadaDTO>>>> GetAll(Pagination pagination)
    {
        var destinos = await _paradaService.GetParadasAsync(pagination);

        if (!destinos.Success)
            return StatusCode(ResponseHelper.GetHttpError(destinos.ErrorCode), destinos);

        return Ok(destinos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> Get(long id)
    {
        var destino = await _paradaService.GetParadaAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);

        return Ok(destino);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> CreateDestino([FromBody] ParadaDTO destinoDto)
    {
        var destino = await _paradaService.CreateParadaAsync(destinoDto);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Created(nameof(Get), destino);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    public async Task<ActionResult<WebResult<ParadaDTO>>> UpdateDestino([FromBody] ParadaDTO destinoDto, long id)
    {
        var destino = await _paradaService.UpdateParadaAsync(destinoDto, id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    public async Task<ActionResult<WebResult<ParadaDTO>>> DeleteDestino(long id)
    {
        var destino = await _paradaService.DeleteParadaAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }


}
*/