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
public class DestinosController : ControllerBase
{
    private readonly IDestinoService _destinoservice;

    public DestinosController(IDestinoService service)
    {
        _destinoservice = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ICollection<DestinoResponse>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<DestinoResponse>>>> GetAll()
    {
        var destinos = await _destinoservice.GetDestinosAsync();

        if (!destinos.Success)
            return StatusCode(ResponseHelper.GetHttpError(destinos.ErrorCode), destinos);

        return Ok(destinos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<DestinoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<DestinoResponse>>> Get(long id)
    {
        var destino = await _destinoservice.GetDestinoAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);

        return Ok(destino);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<DestinoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<DestinoResponse>>> CreateDestino([FromBody] DestinoRequest destinoDto)
    {
        var destino = await _destinoservice.CreateDestinoAsync(destinoDto);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Created(nameof(Get), destino);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<DestinoResponse>))]
    public async Task<ActionResult<WebResult<DestinoResponse>>> UpdateDestino([FromBody] DestinoRequest destinoDto, long id)
    {
        var destino = await _destinoservice.UpdateDestinoAsync(destinoDto, id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<DestinoResponse>))]
    public async Task<ActionResult<WebResult<DestinoResponse>>> DeleteDestino(long id)
    {
        var destino = await _destinoservice.DeleteDestinoAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }


}
