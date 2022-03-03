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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<BoletoDTO>>>> GetAll([FromQuery] BoletoFilter filter)
    {
        var boletos = await _boletoservice.AllPaginatedAsync(filter);

        if (!boletos.Success)
            return StatusCode(ResponseHelper.GetHttpError(boletos.ErrorCode), boletos);

        return Ok(boletos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> Get(int id)
    {
        var boleto = await _boletoservice.GetAsync(new BoletoFilter() { Id = id });

        if (!boleto.Success)
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);

        return Ok(boleto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> CreateBoleto([FromBody] BoletoDTO boletoDto)
    {
        var boleto = await _boletoservice.CreateAsync(boletoDto);

        if (!boleto.Success)
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        return Created(nameof(Get), boleto);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> UpdateBoleto([FromBody] BoletoDTO boletoDto, int id)
    {
        var boleto = await _boletoservice.UpdateAsync(boletoDto, id);

        if (!boleto.Success)
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        return Ok(boleto);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<BoletoDTO>>> DeleteBoleto(int id)
    {
        var boleto = await _boletoservice.DeleteAsync(new BoletoFilter() { Id = id });

        if (!boleto.Success)
            return StatusCode(ResponseHelper.GetHttpError(boleto.ErrorCode), boleto);
        return Ok(boleto);
    }


}
