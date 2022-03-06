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
public class ViajesController : ControllerBase
{
    private readonly IViajeService _viajeservice;

    public ViajesController(IViajeService service)
    {
        _viajeservice = service;
    }

    /// <summary>
    /// Todos los viajes paginados
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ViajeDTO>>>> GetPaginated([FromQuery] ViajeFilter filter)
    {
        var viajes = await _viajeservice.AllPaginatedAsync(filter);

        if (!viajes.Success)
            return StatusCode(ResponseHelper.GetHttpError(viajes.ErrorCode), viajes);

        return Ok(viajes);
    }

    /// <summary>
    /// Todos los viajes sin paginado
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ICollection<ViajeDTO>>>> GetAll()
    {
        var viajes = await _viajeservice.AllAsync(new ViajeFilter() { Estado = Estado.Activo });

        if (!viajes.Success)
            return StatusCode(ResponseHelper.GetHttpError(viajes.ErrorCode), viajes);

        return Ok(viajes);
    }

    /// <summary>
    /// Viaje por id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ViajeDTO>>> Get(int id)
    {
        var viaje = await _viajeservice.GetAsync(new ViajeFilter() { Id = id });

        if (!viaje.Success)
            return StatusCode(ResponseHelper.GetHttpError(viaje.ErrorCode), viaje);

        return Ok(viaje);
    }

    /// <summary>
    /// Crear un viaje
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ViajeDTO>>> CreateViaje([FromBody] ViajeDTO request)
    {
        var viaje = await _viajeservice.CreateAsync(request);

        if (!viaje.Success)
            return StatusCode(ResponseHelper.GetHttpError(viaje.ErrorCode), viaje);
        return Created(nameof(Get), viaje);
    }

    /// <summary>
    /// Modificar un viaje
    /// </summary>
    /// <param name="request"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ViajeDTO>>> UpdateViaje([FromBody] ViajeDTO request, int id)
    {
        var viaje = await _viajeservice.UpdateAsync(request, id);

        if (!viaje.Success)
            return StatusCode(ResponseHelper.GetHttpError(viaje.ErrorCode), viaje);
        return Ok(viaje);
    }

    /// <summary>
    /// Eliminar un viaje
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ViajeDTO>>> DeleteViaje(int id)
    {
        var viaje = await _viajeservice.DeleteAsync(new ViajeFilter() { Id = id });

        if (!viaje.Success)
            return StatusCode(ResponseHelper.GetHttpError(viaje.ErrorCode), viaje);
        return Ok(viaje);
    }

}
