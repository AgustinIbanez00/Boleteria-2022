using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoletosController : ControllerBase
{
    private readonly IBoletoService _boletoservice;

    public BoletosController(IBoletoService service)
    {
        _boletoservice = service;
    }

    /// <summary>
    /// Boletos con paginación
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ICollection<BoletoDTO>>>> GetPaginated([FromQuery] BoletoFilter filter)
    {
        WebResultList<BoletoDTO> boletos = await _boletoservice.AllPaginatedAsync(filter);

        if (!boletos.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(boletos.ErrorCode), boletos);
        }

        return Ok(boletos);
    }

    /// <summary>
    /// Boletos sin paginación
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ICollection<BoletoDTO>>>> GetAll([FromQuery] BoletoFilter filter)
    {
        WebResult<ICollection<BoletoDTO>> boletos = await _boletoservice.AllAsync(filter);

        if (!boletos.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(boletos.ErrorCode), boletos);
        }

        return Ok(boletos);
    }

    /// <summary>
    /// Boleto por id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> Get(int id)
    {
        WebResult<BoletoDTO> boleto = await _boletoservice.GetAsync(new BoletoFilter() { Id = id });

        if (!boleto.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        }

        return Ok(boleto);
    }

    /// <summary>
    /// Crear un boleto
    /// </summary>
    /// <param name="boletoDto"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> CreateBoleto([FromBody] BoletoDTO boletoDto)
    {
        WebResult<BoletoDTO> boleto = await _boletoservice.CreateAsync(boletoDto);

        if (!boleto.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        }

        return Created(nameof(Get), boleto);
    }

    /// <summary>
    /// Modificar un boleto
    /// </summary>
    /// <param name="boletoDto"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> UpdateBoleto([FromBody] BoletoDTO boletoDto, int id)
    {
        WebResult<BoletoDTO> boleto = await _boletoservice.UpdateAsync(boletoDto, id);

        if (!boleto.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        }

        return Ok(boleto);
    }

    /// <summary>
    /// Eliminar un boleto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> DeleteBoleto(int id)
    {
        WebResult<BoletoDTO> boleto = await _boletoservice.DeleteAsync(new BoletoFilter() { Id = id });

        if (!boleto.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        }

        return Ok(boleto);
    }


}
