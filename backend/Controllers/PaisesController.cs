using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaisesController : ControllerBase
{
    private readonly IPaisService _paisService;
    private readonly IProvinciaService _provinciaService;

    public PaisesController(IPaisService paisService, IProvinciaService provinciaService)
    {
        _paisService = paisService;
        _provinciaService = provinciaService;
    }

    /// <summary>
    /// Todos los paises
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<PaisDTO>>>> GetAll([FromQuery] PaisFilter parameters)
    {
        WebResult<List<PaisDTO>> paises = await _paisService.AllAsync(parameters);

        if (!paises.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(paises.ErrorCode), paises);
        }

        return Ok(paises);
    }

    /// <summary>
    /// Todas las provincias de un país
    /// </summary>
    /// <param name="id">id de provincia</param>
    /// <returns></returns>
    [HttpGet("{id:int}/provincias")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<PaisDTO>>>> GetProvincias(int id)
    {
        WebResult<List<ProvinciaDTO>> provincias = await _provinciaService.AllAsync(new ProvinciaFilter() { PaisId = id });

        if (!provincias.Success)
        {
            return StatusCode(ResponseHelper.GetHttpError(provincias.ErrorCode), provincias);
        }

        return Ok(provincias);
    }


}
