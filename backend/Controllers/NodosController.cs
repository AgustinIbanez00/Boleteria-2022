using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BoleteriaOnline.Web.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Responses;

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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<ICollection<NodoResponse>>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<NodoResponse>>>> GetAll()
    {
        var nodos = await _nodoservice.GetNodosAsync();

        if (!nodos.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodos.ErrorCode), nodos);

        return Ok(nodos);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<NodoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<NodoResponse>>> Get(long id)
    {
        var nodo = await _nodoservice.GetNodoAsync(id);

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);

        return Ok(nodo);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<NodoResponse>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<WebResult<NodoResponse>>> CreateNodo([FromBody] NodoRequest nodoDto)
    {
        var nodo = await _nodoservice.CreateNodoAsync(nodoDto);

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);
        return Created(nameof(Get), nodo);
    }

    [HttpPatch]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<NodoResponse>))]
    public async Task<ActionResult<WebResult<NodoResponse>>> UpdateNodo([FromBody] NodoRequest nodoDto)
    {
        var nodo = await _nodoservice.UpdateNodoAsync(nodoDto);

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);
        return Ok(nodo);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WebResult<NodoResponse>))]
    public async Task<ActionResult<WebResult<NodoResponse>>> DeleteNodo(long id)
    {
        var nodo = await _nodoservice.DeleteNodoAsync(id);

        if (!nodo.Success)
            return StatusCode(ResponseHelper.GetHttpError(nodo.ErrorCode), nodo);
        return Ok(nodo);
    }


}
