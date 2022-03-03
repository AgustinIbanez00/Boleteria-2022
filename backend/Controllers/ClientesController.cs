using BoleteriaOnline.Core.Data.Enums;
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

    /// <summary>
    /// Clientes paginados
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ClienteDTO>>>> GetPaginated([FromQuery] ClienteFilter filter)
    {
        var clientes = await _clienteservice.AllPaginatedAsync(filter);

        if (!clientes.Success)
            return StatusCode(ResponseHelper.GetHttpError(clientes.ErrorCode), clientes);

        return Ok(clientes);
    }

    /// <summary>
    /// Clientes sin paginado
    /// </summary>
    /// <returns></returns>
    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ICollection<ClienteDTO>>>> GetAll()
    {
        var clientes = await _clienteservice.AllAsync(new ClienteFilter() { Estado = Estado.Activo });

        if (!clientes.Success)
            return StatusCode(ResponseHelper.GetHttpError(clientes.ErrorCode), clientes);

        return Ok(clientes);
    }

    /// <summary>
    /// Clientes por id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:long}")]
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

    /// <summary>
    /// Crear un cliente
    /// </summary>
    /// <param name="clienteDto"></param>
    /// <returns></returns>
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

    /// <summary>
    /// Modificar un cliente
    /// </summary>
    /// <param name="clienteDto"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPatch("{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<ClienteDTO>>> UpdateCliente([FromBody] ClienteDTO clienteDto, long id)
    {
        var cliente = await _clienteservice.UpdateAsync(clienteDto, id);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Ok(cliente);
    }

    /// <summary>
    /// Eliminar una parada
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
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
