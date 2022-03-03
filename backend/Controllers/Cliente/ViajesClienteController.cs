using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ViajesClienteController : ControllerBase
{
    private readonly IViajeClienteService _viajeClienteService;

    public ViajesClienteController(IViajeClienteService service)
    {
        _viajeClienteService = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ViajeClienteDTO>>>> GetAll([FromQuery] ViajeClienteFilter filter)
    {
        var viajes = await _viajeClienteService.AllAsync(filter);

        if (!viajes.Success)
            return StatusCode(ResponseHelper.GetHttpError(viajes.ErrorCode), viajes);

        return Ok(viajes);
    }


}
