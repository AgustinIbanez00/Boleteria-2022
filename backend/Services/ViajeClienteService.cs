using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;
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

        public async Task<WebResult<ICollection<ViajeClienteDTO>>> AllAsync(ViajeClienteFilter filter)
        {
            try
            {
                var paradaOrigen = await _paradaRepository.GetAsync(new ParadaFilter() { Nombre = filter.Origen });

                if (paradaOrigen == null)
                    return KeyError<ParadaDTO, ICollection<ViajeClienteDTO>>(nameof(filter.Origen), ErrorMessage.NotFound);

                var paradaDestino = await _paradaRepository.GetAsync(new ParadaFilter() { Nombre = filter.Origen });

                if (paradaDestino == null)
                    return KeyError<ParadaDTO, ICollection<ViajeClienteDTO>>(nameof(filter.Destino), ErrorMessage.NotFound);

                DateTime fechaDateTime = DateTime.MinValue;

                if (!DateTime.TryParse(filter.Fecha, out fechaDateTime))
                    return KeyError<ICollection<ViajeClienteDTO>>(nameof(filter.Fecha), "No se pudo convertir la fecha solicitada.");

                if (fechaDateTime < DateTime.Now)
                    return KeyError<ICollection<ViajeClienteDTO>>(nameof(filter.Fecha), "La fecha debe ser mayor a la fecha actual.");

                var viajesId = await _context.Nodos.Select(x => x.ViajeId).Distinct().ToListAsync();

                var viajesAceptados = new List<ViajeClienteDTO>();

                foreach (var viajeId in viajesId)
                {
                    foreach (var viaje in _context.Viajes.Include(x => x.Horarios).Where(x => x.Id == viajeId && x.Horarios.Exists(h => ((DateTime.Now.DayOfWeek == DayOfWeek.Monday && h.Lunes) || (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && h.Martes) || (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && h.Miercoles) || (DateTime.Now.DayOfWeek == DayOfWeek.Thursday && h.Jueves) || (DateTime.Now.DayOfWeek == DayOfWeek.Friday && h.Viernes) || (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && h.Sabado) || (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && h.Domingo)))))
                    {
                        var horario = await _context.Horarios.FirstOrDefaultAsync(h => ((DateTime.Now.DayOfWeek == DayOfWeek.Monday && h.Lunes) || (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && h.Martes) || (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && h.Miercoles) || (DateTime.Now.DayOfWeek == DayOfWeek.Thursday && h.Jueves) || (DateTime.Now.DayOfWeek == DayOfWeek.Friday && h.Viernes) || (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && h.Sabado) || (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && h.Domingo)));

                        var nodosPorViaje = await _context.Nodos.Where(x => (x.OrigenId == paradaOrigen.Id || x.DestinoId == paradaDestino.Id) && x.ViajeId == viajeId).OrderBy(x => x.Id).ToListAsync();

                        if (nodosPorViaje.Count == 2)
                        {
                            // EL ID DEL NODO ORIGEN (ÍNDICE 0) DEBE SER MENOR AL ID DEL NODO DESTINO (ÍNDICE 1)
                            if (nodosPorViaje[0].Id < nodosPorViaje[1].Id)
                            {
                                DateTime? horarioSalida = await CalcularFechaAsync(viaje, horario, paradaOrigen, true);
                                DateTime? horarioLlegada = await CalcularFechaAsync(viaje, horario, paradaOrigen, false);

                                var viajesDto = new ViajeClienteDTO()
                                {
                                    Empresa = "Boletería Online",
                                    HorarioSalida = horarioSalida.HasValue ? horarioSalida.Value.ToString("HH:mm") : "00:00:00",
                                    HorarioLlegada = horarioLlegada.HasValue ? horarioLlegada.Value.ToString("HH:mm") : "00:00:00"
                                    //AsientosDisponibles = _context.Boletos.Where(b => b.OrigenId == paradaOrigen.Id && b.DestinoId == paradaDestino.Id)
                                };

                                viajesAceptados.Add(viajesDto);
                            }
                        }
                    }
                }
                return Ok<ICollection<ViajeClienteDTO>>(viajesAceptados);
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public async Task<DateTime?> CalcularFechaAsync(Viaje viaje, Horario horario, Parada parada, bool Origen)
        {
            var nodos = await _context.Nodos.Where(x => x.ViajeId == viaje.Id).ToListAsync();

            DateTime inicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, horario.Hora.Hour, horario.Hora.Minute, horario.Hora.Second);

            foreach (var nodo in nodos)
            {
                TimeSpan timeSpanNodo = TimeSpan.Parse(nodo.Demora);

                inicial = inicial.Add(timeSpanNodo);

                if (Origen && nodo.OrigenId == parada.Id || !Origen && nodo.DestinoId == parada.Id)
                    return inicial;
            }
            return null;
        }

    }
}
