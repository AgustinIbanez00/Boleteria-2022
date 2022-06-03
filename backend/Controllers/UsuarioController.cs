using System.Security.Claims;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService service)
    {
        _usuarioService = service;
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<UsuarioResponse>>> Get(int id)
    {
        WebResult<UsuarioResponse> usuario = await _usuarioService.GetUsuarioAsync(id);

        if (!usuario.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(usuario.ErrorCode), usuario);
        }

        return Ok(usuario);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<ActionResult<WebResult<UsuarioResponse>>> RegisterUsuario([FromBody] RegistroRequest usuarioDto)
    {
        WebResult<UsuarioResponse> usuario = await _usuarioService.CreateUsuarioAsync(usuarioDto);

        if (!usuario.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(usuario.ErrorCode), usuario);
        }

        return Created(nameof(Get), usuario);
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<ActionResult<WebResult<LoginResponse>>> LoginUsuario([FromBody] LoginRequest usuarioDto)
    {
        WebResult<LoginResponse> usuario = await _usuarioService.LoginUsuarioAsync(usuarioDto);

        if (!usuario.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(usuario.ErrorCode), usuario);
        }

        return Ok(usuario);
    }

    [HttpPost("ban")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<UsuarioResponse>>> LockUsuario(int id)
    {
        WebResult<UsuarioResponse> usuario = await _usuarioService.LockUsuarioAsync(id);

        if (!usuario.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(usuario.ErrorCode), usuario);
        }

        return Ok(usuario);
    }

    [HttpGet("me")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<WebResult<UsuarioResponse>>> GetMe()
    {
        Claim currentClaim = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
        if (currentClaim == null)
        {
            return BadRequest(WebResponse.Error<UsuarioResponse>("El token actual es inválido o contiene información errónea."));
        }

        WebResult<UsuarioResponse> usuario = await _usuarioService.GetUsuarioByEmailAsync(currentClaim.Value);

        if (!usuario.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(usuario.ErrorCode), usuario);
        }

        return Ok(usuario);
    }

}
