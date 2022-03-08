using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using static BoleteriaOnline.Core.Utils.WebResponse;

namespace BoleteriaOnline.Web.Services
{
    public class ViajeClienteService : IViajeClienteService
    {
        private readonly IViajeClienteRepository _viajeClienteRepository;

        public ViajeClienteService(IViajeClienteRepository viajeClienteRepository)
        {
            _viajeClienteRepository = viajeClienteRepository;
        }

        public async Task<WebResult<ICollection<ViajeClienteDTO>>> AllAsync(ViajeClienteFilter filter)
        {
            try
            {
                var result = await _viajeClienteRepository.GetAllAsync(filter);

                if(result == null)
                {
                    return Error<Viaje, ICollection<ViajeClienteDTO>>(ErrorMessage.EmptyList);
                }


                return Ok(result);
            }
            catch (Exception ex)
            {
                return Error<Viaje, ICollection<ViajeClienteDTO>>(ErrorMessage.Generic, ex.Message);
            }
        }
    }
}
