using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NodosController : ControllerBase
{
    private readonly INodoService _nodoservice;

    public NodosController(INodoService service)
    {
        _nodoservice = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<NodoDTO>>>> GetAll()
    {
        var nodos = await _nodoservice.AllPaginatedAsync(new NodoFilter());

        if (!nodos.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodos.ErrorCode), nodos);

        return Ok(nodos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<NodoDTO>>> Get(int id)
    {
        var nodo = await _nodoservice.GetAsync(new NodoFilter() { Id = id});

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);

        return Ok(nodo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<NodoDTO>>> CreateNodo([FromBody] NodoDTO nodoDto)
    {
        var nodo = await _nodoservice.CreateAsync(nodoDto);

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);
        return Created(nameof(Get), nodo);
    }

    [HttpPatch("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<NodoDTO>>> UpdateNodo([FromBody] NodoDTO nodoDto, int id)
    {
        var nodo = await _nodoservice.UpdateAsync(nodoDto, id);

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);
        return Ok(nodo);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<NodoDTO>>> DeleteNodo(int id)
    {
        var nodo = await _nodoservice.DeleteAsync(new NodoFilter() { Id = id});

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);
        return Ok(nodo);
    }


}
