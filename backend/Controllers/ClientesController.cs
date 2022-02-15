using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BoleteriaOnline.Web.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Core.Utils;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ICollection<ClienteResponse>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ClienteResponse>>>> GetAll()
    {
        var clientes = await _clienteservice.GetClientesAsync();

        if (!clientes.Success)
            return StatusCode(ResponseHelper.GetHttpError(clientes.ErrorCode), clientes);

        return Ok(clientes);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ClienteResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ClienteResponse>>> Get(long id)
    {
        var cliente = await _clienteservice.GetClienteAsync(id);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);

        return Ok(cliente);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ClienteResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<ClienteResponse>>> CreateCliente([FromBody] ClienteRequest clienteDto)
    {
        var cliente = await _clienteservice.CreateClienteAsync(clienteDto);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Created(nameof(Get), cliente);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ClienteResponse>))]
    public async Task<ActionResult<WebResult<ClienteResponse>>> UpdateCliente([FromBody] ClienteRequest clienteDto)
    {
        var cliente = await _clienteservice.UpdateClienteAsync(clienteDto);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Ok(cliente);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ClienteResponse>))]
    public async Task<ActionResult<WebResult<ClienteResponse>>> DeleteCliente(long id)
    {
        var cliente = await _clienteservice.DeleteClienteAsync(id);

        if (!cliente.Success)
            return StatusCode(ResponseHelper.GetHttpError(cliente.ErrorCode), cliente);
        return Ok(cliente);
    }


}
