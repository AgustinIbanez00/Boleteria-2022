using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Extensions.Response;
using Microsoft.AspNetCore.Mvc;

namespace BoleteriaOnline.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ViajesClienteController : ControllerBase
{
    private readonly IViajeClienteService _viajeservice;

    public ViajesClienteController(IViajeClienteService service)
    {
        _viajeservice = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WebResult<ICollection<ViajeDTO>>>> GetAll([FromQuery] ViajeClienteFilter filter)
    {
        var viajes = await _viajeservice.AllAsync(filter);

        if (!viajes.Success)
            return StatusCode(ResponseHelper.GetHttpError(viajes.ErrorCode), viajes);

        return Ok(viajes);
    }


}
