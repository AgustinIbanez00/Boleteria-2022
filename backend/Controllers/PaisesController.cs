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

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<PaisDTO>>>> GetAll([FromQuery] PaisFilter parameters)
    {
        var paises = await _paisService.AllAsync(parameters);

        if (!paises.Success)
            return StatusCode(ResponseHelper.GetHttpError(paises.ErrorCode), paises);

        return Ok(paises);
    }

    [HttpGet("{id:int}/provincias")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<PaisDTO>>>> GetProvincias(int id)
    {
        var provincias = await _provinciaService.AllAsync(new ProvinciaFilter() { PaisId = id });

        if (!provincias.Success)
            return StatusCode(ResponseHelper.GetHttpError(provincias.ErrorCode), provincias);

        return Ok(provincias);
    }


}
