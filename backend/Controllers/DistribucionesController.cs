using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DistribucionesController : ControllerBase
{
    private readonly IDistribucionService _distribucionservice;

    public DistribucionesController(IDistribucionService service)
    {
        _distribucionservice = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<DistribucionResponse>>>> GetAll()
    {
        var distribucions = await _distribucionservice.GetDistribucionesAsync();

        if (!distribucions.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucions.ErrorCode), distribucions);

        return Ok(distribucions);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<DistribucionResponse>>> Get(long id)
    {
        var distribucion = await _distribucionservice.GetDistribucionAsync(id);

        if (!distribucion.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucion.ErrorCode), distribucion);

        return Ok(distribucion);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<DistribucionResponse>>> CreateDistribucion([FromBody] DistribucionRequest distribucionDto)
    {
        var distribucion = await _distribucionservice.CreateDistribucionAsync(distribucionDto);

        if (!distribucion.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucion.ErrorCode), distribucion);
        return Created(nameof(Get), distribucion);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<DistribucionResponse>>> UpdateDistribucion([FromBody] DistribucionUpdateRequest distribucionDto)
    {
        var distribucion = await _distribucionservice.UpdateDistribucionAsync(distribucionDto);

        if (!distribucion.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucion.ErrorCode), distribucion);
        return Ok(distribucion);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<DistribucionResponse>>> DeleteDistribucion(long id)
    {
        var distribucion = await _distribucionservice.DeleteDistribucionAsync(id);

        if (!distribucion.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucion.ErrorCode), distribucion);
        return Ok(distribucion);
    }


    [HttpPost("{id:int}/filas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<DistribucionResponse>>> CreateFilas(long id, [FromBody] Planta planta)
    {
        var distribucion = await _distribucionservice.AppendFilasAsync(id, planta);

        if (!distribucion.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucion.ErrorCode), distribucion);
        return Ok(distribucion);
    }

    /*
    [HttpGet("{viajeId:int}/filas")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<DistribucionResponse>>> Compra(long viajeId, [FromBody] Planta planta)
    {
        var distribucion = await _distribucionservice.AppendFilasAsync(id, planta);

        if (!distribucion.Success)
            return StatusCode(ResponseHelper.GetHttpError(distribucion.ErrorCode), distribucion);
        return Ok(distribucion);
    }
    */
}
