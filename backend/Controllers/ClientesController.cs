using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Web.Data.Filters;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IClienteService _clienteservice;

    public ClientesController(IClienteService service)
    {
        _clienteservice = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ClienteDTO>>>> GetAll([FromQuery] ClienteFilter filter)
    {
        var clientes = await _clienteservice.AllAsync(filter);

        if (!clientes.Success)
            return StatusCode(ResponseHelper.GetHttpError(clientes.ErrorCode), clientes);

        return Ok(clientes);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ClienteDTO>>> Get(long id)
    {
        var cliente = await _clienteservice.GetAsync(new ClienteFilter() { Dni = id });

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);

        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ClienteDTO>>> CreateCliente([FromBody] ClienteDTO clienteDto)
    {
        var cliente = await _clienteservice.CreateAsync(clienteDto);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Created(nameof(Get), cliente);
    }

    [HttpPatch("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ClienteDTO>>> UpdateCliente([FromBody] ClienteDTO clienteDto, long id)
    {
        var cliente = await _clienteservice.UpdateAsync(clienteDto, id);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Ok(cliente);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ClienteDTO>>> DeleteCliente(long id)
    {
        var cliente = await _clienteservice.DeleteAsync(new ClienteFilter() { Dni = id });

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Ok(cliente);
    }


}
