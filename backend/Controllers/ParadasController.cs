using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BoleteriaOnline.Web.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Responses;

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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ICollection<ParadaResponse>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ParadaResponse>>>> GetAll()
    {
        var destinos = await _paradaService.GetParadasAsync();

        if (!destinos.Success)
            return StatusCode(ResponseHelper.GetHttpError(destinos.ErrorCode), destinos);

        return Ok(destinos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ParadaResponse>>> Get(long id)
    {
        var destino = await _paradaService.GetParadaAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);

        return Ok(destino);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ParadaResponse>>> CreateDestino([FromBody] ParadaRequest destinoDto)
    {
        var destino = await _paradaService.CreateParadaAsync(destinoDto);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Created(nameof(Get), destino);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaResponse>))]
    public async Task<ActionResult<WebResult<ParadaResponse>>> UpdateDestino([FromBody] ParadaRequest destinoDto, long id)
    {
        var destino = await _paradaService.UpdateParadaAsync(destinoDto, id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaResponse>))]
    public async Task<ActionResult<WebResult<ParadaResponse>>> DeleteDestino(long id)
    {
        var destino = await _paradaService.DeleteParadaAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }


}
