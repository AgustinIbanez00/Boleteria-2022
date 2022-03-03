using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using EntityFramework.Exceptions.Common;

namespace BoleteriaOnline.Web.Services;
using static WebResponse;
public class ViajeService : IViajeService
{
    private readonly IMapper _mapper;
    private readonly IViajeRepository _viajeRepository;
    private readonly IDistribucionRepository _distribucionRepository;
    private readonly INodoRepository _nodoRepository;

    public ViajeService(IMapper mapper, IViajeRepository viajeRepository, IDistribucionRepository distribucionRepository, INodoRepository nodoRepository)
    {
        _mapper = mapper;
        _viajeRepository = viajeRepository;
        _distribucionRepository = distribucionRepository;
        _nodoRepository = nodoRepository;
    }
    public async Task<WebResult<ICollection<ViajeDTO>>> AllAsync(ViajeFilter filter)
    {
        try
        {
            var viajes = await _viajeRepository.GetAllAsync(filter);

            var viajesDto = new List<ViajeDTO>();

            foreach (var viaje in viajes)
            {
                viajesDto.Add(_mapper.Map<ViajeDTO>(viaje));
            }

            return Ok<ICollection<ViajeDTO>>(viajesDto);
        }
        catch (Exception ex)
        {
            return Error<ICollection<ViajeDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResultList<ViajeDTO>> AllPaginatedAsync(ViajeFilter filter)
    {
        try
        {
            PaginatedList<Viaje> viajes = await _viajeRepository.GetAllPaginatedAsync(filter);

            var viajesDto = new List<ViajeDTO>();

            foreach (var viaje in viajes)
            {
                viajesDto.Add(_mapper.Map<ViajeDTO>(viaje));
            }

            return List(viajesDto, Pagination.Page(viajes.TotalItems, filter.Pagina, filter.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<ViajeDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ViajeDTO>> CreateAsync(ViajeDTO request)
    {
        try
        {
            if (request.Horarios.Count == 0)
                return Error<Horario, ViajeDTO>(ErrorMessage.EmptyList);

            foreach (var horario in request.Horarios)
            {
                horario.Id = 0;
                if (!await _distribucionRepository.ExistsDistribucionAsync(horario.DistribucionId))
                    return Error<Distribucion, ViajeDTO>(ErrorMessage.NotFound);
            }

            Viaje viaje = _mapper.Map<Viaje>(request);

            if (!await _viajeRepository.CreateAsync(viaje))
                return Error<Viaje, ViajeDTO>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ViajeDTO>(viaje);
            return Ok<Viaje, ViajeDTO>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Viaje, ViajeDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ViajeDTO>> DeleteAsync(ViajeFilter filter)
    {
        try
        {
            var viaje = await _viajeRepository.GetAsync(filter);
            if (viaje == null)
                return Error<Viaje, ViajeDTO>(ErrorMessage.NotFound);

            if (!await _viajeRepository.DeleteAsync(viaje))
                return Error<Viaje, ViajeDTO>(ErrorMessage.CouldNotDelete);

            return Ok<Viaje, ViajeDTO>(_mapper.Map<ViajeDTO>(viaje), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ViajeDTO>> GetAsync(ViajeFilter filter)
    {
        try
        {
            var viaje = await _viajeRepository.GetAsync(filter);

            if (viaje == null)
                return Error<ViajeDTO>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ViajeDTO>(viaje));
        }
        catch (Exception ex)
        {
            return Error<ViajeDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ViajeDTO>> UpdateAsync(ViajeDTO request, int id)
    {
        try
        {
            if (id <= 0)
                return Error<Viaje, ViajeDTO>(ErrorMessage.InvalidId);

            var viaje = await _viajeRepository.GetAsync(new ViajeFilter() { Id = id});

            if (viaje == null)
                return Error<Viaje, ViajeDTO>(ErrorMessage.NotFound);

            viaje.Nombre = request.Nombre;

            await _nodoRepository.DeleteAsync(new NodoFilter() {  ViajeId = id });

            foreach (var nodo in request.Conexiones)
            {
                viaje.Nodos.Add(_mapper.Map<Nodo>(nodo));
            }

            if (!await _viajeRepository.UpdateAsync(viaje))
                return Error<Viaje, ViajeDTO>(ErrorMessage.CouldNotUpdate);

            return Ok<Viaje, ViajeDTO>(_mapper.Map<ViajeDTO>(viaje), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Viaje, ViajeDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public Task<WebResult<ViajeDTO>> ValidateAsync(ViajeDTO request)
    {
        throw new NotImplementedException();
    }
}
