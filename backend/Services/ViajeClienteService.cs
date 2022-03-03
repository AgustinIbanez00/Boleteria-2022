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
                var paradaOrigen = await _paradaRepository.FindAsync(filter.OrigenId);

                if (paradaOrigen == null)
                    return KeyError<ParadaDTO, ICollection<ViajeClienteDTO>>(nameof(filter.OrigenId), ErrorMessage.NotFound);

                var paradaDestino = await _paradaRepository.FindAsync(filter.DestinoId);

                if (paradaDestino == null)
                    return KeyError<ParadaDTO, ICollection<ViajeClienteDTO>>(nameof(filter.DestinoId), ErrorMessage.NotFound);

                DateTime fechaDateTime = DateTime.MinValue;

                if (!DateTime.TryParse(filter.Fecha, out fechaDateTime))
                    return KeyError<ICollection<ViajeClienteDTO>>(nameof(filter.Fecha), "No se pudo convertir la fecha solicitada.");

                if (fechaDateTime < DateTime.Now)
                    return KeyError<ICollection<ViajeClienteDTO>>(nameof(filter.Fecha), "La fecha debe ser mayor a la fecha actual.");

                var viajesId = await _context.Nodos.Select(x => x.ViajeId).Distinct().ToListAsync();

                var viajesAceptados = new List<ViajeClienteDTO>();

                foreach (var viajeId in viajesId)
                {
                    foreach (var viaje in _context.Viajes.Include(x => x.Horarios).Include(x => x.Nodos).Where(x => x.Id == viajeId))
                    {
                        //.Where(h => ((DateTime.Now.DayOfWeek == DayOfWeek.Monday && h.Lunes) || (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && h.Martes) || (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && h.Miercoles) || (DateTime.Now.DayOfWeek == DayOfWeek.Thursday && h.Jueves) || (DateTime.Now.DayOfWeek == DayOfWeek.Friday && h.Viernes) || (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && h.Sabado) || (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && h.Domingo))
                        var horario = viaje.Horarios.FirstOrDefault(h => (DateTime.Now.DayOfWeek == DayOfWeek.Monday && h.Lunes) || (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday && h.Martes) || (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday && h.Miercoles) || (DateTime.Now.DayOfWeek == DayOfWeek.Thursday && h.Jueves) || (DateTime.Now.DayOfWeek == DayOfWeek.Friday && h.Viernes) || (DateTime.Now.DayOfWeek == DayOfWeek.Saturday && h.Sabado) || (DateTime.Now.DayOfWeek == DayOfWeek.Sunday && h.Domingo));

                        if (horario == null)
                            continue;

                        var nodosPorViaje = viaje.Nodos.Where(x => x.OrigenId == paradaOrigen.Id || x.DestinoId == paradaDestino.Id).ToList();

                        if (nodosPorViaje.Count == 2)
                        {
                            // EL ID DEL NODO ORIGEN (ÍNDICE 0) DEBE SER MENOR AL ID DEL NODO DESTINO (ÍNDICE 1)
                            if (nodosPorViaje[0].Id < nodosPorViaje[1].Id)
                            {

                                DateTime? horarioSalida = CalcularFecha(viaje.Nodos.ToList(), viaje, horario, paradaOrigen, true);
                                DateTime? horarioLlegada = CalcularFecha(viaje.Nodos.ToList(), viaje, horario, paradaDestino, false);

                                //var asientosDisponibles = _context.Boletos.Where(b => b.RecorridoId == viaje.Id && b.OrigenId == paradaOrigen.Id && b.DestinoId == paradaDestino.Id && b.Fecha.Date == DateTime.Now.Date);

                                var viajesDto = new ViajeClienteDTO()
                                {
                                    Empresa = "Boletería Online",
                                    HorarioSalida = horarioSalida.HasValue ? horarioSalida.Value.ToString("HH:mm") : "00:00:00",
                                    HorarioLlegada = horarioLlegada.HasValue ? horarioLlegada.Value.ToString("HH:mm") : "00:00:00"
                                    
                                    //AsientosDisponibles = asientosDisponibles
                                };

                                viajesAceptados.Add(viajesDto);
                            }
                        }

                    }
                }
                return Ok<ICollection<ViajeClienteDTO>>(viajesAceptados);
            }
            catch (Exception ex)
            {
                return Error<Viaje, ICollection<ViajeClienteDTO>>(ErrorMessage.Generic, ex.Message);
            }
        }

        public DateTime? CalcularFecha(List<Nodo> nodos, Viaje viaje, Horario horario, Parada parada, bool Origen)
        {
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
