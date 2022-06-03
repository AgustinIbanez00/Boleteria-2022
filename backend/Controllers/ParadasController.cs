using BoleteriaOnline.Core.Data.Enums;
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
    /// Todas las paradas con filtro
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResultList<ParadaDTO>>> GetPaginated([FromQuery] ParadaFilter filter)
    {
        WebResultList<ParadaDTO> paradas = await _paradaService.AllPaginatedAsync(filter);

        if (!paradas.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(paradas.ErrorCode), paradas);
        }
        else
        {
            Response.Headers.Add("cantidadTotalRegistros", paradas.Result.Capacity.ToString());
        }

        return Ok(paradas);
    }

    /// <summary>
    /// Todas las paradas sin filtro
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ICollection<ParadaDTO>>>> GetAll()
    {
        WebResult<ICollection<ParadaDTO>> paradas = await _paradaService.AllAsync(new ParadaFilter() { Estado = Estado.Activo });

        if (!paradas.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(paradas.ErrorCode), paradas);
        }

        return Ok(paradas);
    }

    /// <summary>
    /// Parada por id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> Get(int id)
    {
        WebResult<ParadaDTO> parada = await _paradaService.GetAsync(new ParadaFilter() { Id = id });

        if (!parada.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(parada.ErrorCode), parada);
        }

        return Ok(parada);
    }

    /// <summary>
    /// Crear una parada
    /// </summary>
    /// <param name="paradaDto"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> CreateParada([FromBody] ParadaDTO paradaDto)
    {
        WebResult<ParadaDTO> parada = await _paradaService.CreateAsync(paradaDto);

        if (!parada.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(parada.ErrorCode), parada);
        }

        return Created(nameof(Get), parada);
    }

    /// <summary>
    /// Modificar una parada
    /// </summary>
    /// <param name="paradaDto"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> UpdateParada([FromBody] ParadaDTO paradaDto, int id)
    {
        WebResult<ParadaDTO> parada = await _paradaService.UpdateAsync(paradaDto, id);

        if (!parada.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(parada.ErrorCode), parada);
        }

        return Ok(parada);
    }

    /// <summary>
    /// Eliminar una parada
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ParadaDTO>>> DeleteParada(int id)
    {
        WebResult<ParadaDTO> parada = await _paradaService.DeleteAsync(new ParadaFilter() { Id = id });

        if (!parada.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(parada.ErrorCode), parada);
        }

        return Ok(parada);
    }


}
