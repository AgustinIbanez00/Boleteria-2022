using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParadasController : ControllerBase
{
    private readonly IParadaService _paradaService;

    public ParadasController(IParadaService service)
    {
        _paradaService = service;
    }
    /// <summary>
    /// Devuelve todas las paradas que cumplan la condición del filtro.
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResultList<ParadaDTO>>> GetAll([FromQuery] ParadaFilter filter)
    {
        var paradas = await _paradaService.AllAsync(filter);

        if (!paradas.Success)
            return StatusCode(ResponseHelper.GetHttpError(paradas.ErrorCode), paradas);
        else
            Response.Headers.Add("cantidadTotalRegistros", paradas.Result.Capacity.ToString());

        return Ok(paradas);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> Get(int id)
    {
        var destino = await _paradaService.GetAsync(new ParadaFilter() { Id = id });

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);

        return Ok(destino);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> CreateDestino([FromBody] ParadaDTO destinoDto)
    {
        var destino = await _paradaService.CreateAsync(destinoDto);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Created(nameof(Get), destino);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> UpdateDestino([FromBody] ParadaDTO destinoDto, int id)
    {
        var destino = await _paradaService.UpdateAsync(destinoDto, id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> DeleteDestino(int id)
    {
        var destino = await _paradaService.DeleteAsync(new ParadaFilter() { Id = id });

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }


}
