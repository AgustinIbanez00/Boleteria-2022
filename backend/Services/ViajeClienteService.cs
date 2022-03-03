using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Repositories;
using BoleteriaOnline.Web.Repository;
using static BoleteriaOnline.Core.Utils.WebResponse;

namespace BoleteriaOnline.Web.Services
{
    public class ViajeClienteService : IViajeClienteService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IParadaRepository _paradaRepository;
        private readonly INodoRepository _nodoRepository;
        private readonly IViajeClienteRepository _viajeRepository;

        public ViajeClienteService(IMapper mapper, ApplicationDbContext context, IParadaRepository paradaRepository, INodoRepository nodoRepository)
        {
            _mapper = mapper;
            _context = context;
            _paradaRepository = paradaRepository;
            _nodoRepository = nodoRepository;
        }

        public async Task<WebResultList<ViajeClienteDTO>> AllAsync(ViajeClienteFilter filter)
        {
            try
            {
                var paradaOrigen = await _paradaRepository.GetAsync(new ParadaFilter() { Nombre = filter.Origen });

                if (paradaOrigen == null)
                    return KeyErrorList<ParadaDTO, ViajeClienteDTO>(nameof(filter.Origen), ErrorMessage.NotFound);

                var paradaDestino = await _paradaRepository.GetAsync(new ParadaFilter() { Nombre = filter.Origen });

                if (paradaDestino == null)
                    return KeyErrorList<ParadaDTO, ViajeClienteDTO>(nameof(filter.Destino), ErrorMessage.NotFound);

                DateTime fechaDateTime = DateTime.MinValue;

                if (!DateTime.TryParse(filter.Fecha, out fechaDateTime))
                    return ErrorList<ViajeClienteDTO>("No se pudo convertir la fecha solicitada.");

                if(fechaDateTime < DateTime.Now)
                    return ErrorList<ViajeClienteDTO>("La fecha debe ser mayor a la fecha actual.");

                var nodos = _context.Nodos.Where(n => n.OrigenId == paradaOrigen.Id);




                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
