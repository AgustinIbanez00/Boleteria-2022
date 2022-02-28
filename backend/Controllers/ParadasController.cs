using Microsoft.AspNetCore.Mvc;
using BoleteriaOnline.Web.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Pagging;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ICollection<ParadaDTO>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<PaginatedList<ParadaDTO>>>> GetAll([FromQuery] Pagination parameters)
    {
        WebResult<PaginatedList<ParadaDTO>> paradas = await _paradaService.AllAsync(parameters);
        

        if (!paradas.Success)
            return StatusCode(ResponseHelper.GetHttpError(paradas.ErrorCode), paradas);
        else
            Response.Headers.Add("cantidadTotalRegistros", paradas.Result.Capacity.ToString());

        return Ok(paradas);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> Get(long id)
    {
        var destino = await _paradaService.GetAsync(id);

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
        var destino = await _paradaService.CreateAsync(destinoDto);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Created(nameof(Get), destino);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    public async Task<ActionResult<WebResult<ParadaDTO>>> UpdateDestino([FromBody] ParadaDTO destinoDto, long id)
    {
        var destino = await _paradaService.UpdateAsync(destinoDto, id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ParadaDTO>))]
    public async Task<ActionResult<WebResult<ParadaDTO>>> DeleteDestino(long id)
    {
        var destino = await _paradaService.DeleteAsync(id);

        if (!destino.Success)
            return StatusCode(ResponseHelper.GetHttpError(destino.ErrorCode), destino);
        return Ok(destino);
    }


}
