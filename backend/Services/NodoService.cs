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
public class NodoService : INodoService
{
    private readonly IMapper _mapper;
    private readonly INodoRepository _nodoRepository;
    private readonly IParadaRepository _paradaRepository;

    public NodoService(IMapper mapper, INodoRepository nodoRepository, IParadaRepository paradaRepository)
    {
        _mapper = mapper;
        _nodoRepository = nodoRepository;
        _paradaRepository = paradaRepository;
    }


    public async Task<WebResult<ICollection<NodoDTO>>> AllAsync(NodoFilter filter)
    {
        try
        {
            PaginatedList<Nodo> nodos = await _nodoRepository.GetAllPaginatedAsync(filter);

            List<NodoDTO> nodosDto = new();

            foreach (Nodo cliente in nodos)
            {
                nodosDto.Add(_mapper.Map<NodoDTO>(cliente));
            }
            return Ok<ICollection<NodoDTO>>(nodosDto);
        }
        catch (Exception ex)
        {
            return Error<ICollection<NodoDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResultList<NodoDTO>> AllPaginatedAsync(NodoFilter filter)
    {
        try
        {
            PaginatedList<Nodo> nodos = await _nodoRepository.GetAllPaginatedAsync(filter);

            List<NodoDTO> nodosDto = new();

            foreach (Nodo nodo in nodos)
            {
                nodosDto.Add(_mapper.Map<NodoDTO>(nodo));
            }

            return List(nodosDto, Pagination.Page(nodos.TotalItems, filter.Pagina, filter.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<NodoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<NodoDTO>> CreateAsync(NodoDTO request)
    {
        try
        {
            Nodo nodo = _mapper.Map<Nodo>(request);

            Parada nodoDtoOrigen = await _paradaRepository.FindAsync(request.OrigenId);

            if (nodoDtoOrigen != null)
            {
                nodo.Origen = nodoDtoOrigen;
            }
            else
            {
                return KeyError<Parada, NodoDTO>(nameof(request.OrigenId), ErrorMessage.NotFound);
            }

            Parada nodoDtoDestino = await _paradaRepository.FindAsync(request.DestinoId);

            if (nodoDtoDestino != null)
            {
                nodo.Destino = nodoDtoDestino;
            }
            else
            {
                return KeyError<Parada, NodoDTO>(nameof(request.DestinoId), ErrorMessage.NotFound);
            }

            if (nodo.Origen == nodo.Destino)
            {
                return Error<NodoDTO>("El nodo origen no puede ser igual al nodo destino.");
            }

            if (!await _nodoRepository.CreateAsync(nodo))
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.CouldNotCreate);
            }

            NodoDTO dto = _mapper.Map<NodoDTO>(nodo);
            return Ok<Nodo, NodoDTO>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Nodo, NodoDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<NodoDTO>> DeleteAsync(NodoFilter filter)
    {
        try
        {
            Nodo nodo = await _nodoRepository.GetAsync(filter);
            if (nodo == null)
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.NotFound);
            }

            if (!await _nodoRepository.DeleteAsync(nodo))
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.CouldNotDelete);
            }

            return Ok<Nodo, NodoDTO>(_mapper.Map<NodoDTO>(nodo), SuccessMessage.Deleted);
        }
        catch (ReferenceConstraintException)
        {
            return Error<NodoDTO>(ErrorMessage.CouldNotDeleteReferenced);
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }


    public async Task<WebResult<NodoDTO>> GetAsync(NodoFilter filter)
    {
        try
        {
            Nodo nodo = await _nodoRepository.GetAsync(filter);

            if (nodo == null)
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.NotFound);
            }

            return Ok(_mapper.Map<NodoDTO>(nodo));
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ICollection<NodoDTO>>> GetNodosAsync()
    {
        try
        {
            ICollection<Nodo> nodos = await _nodoRepository.GetAllAsync(new NodoFilter());

            List<NodoDTO> nodosDto = new();

            foreach (Nodo Nodo in nodos)
            {
                nodosDto.Add(_mapper.Map<NodoDTO>(Nodo));
            }
            return Ok<ICollection<NodoDTO>>(nodosDto);
        }
        catch (Exception ex)
        {
            return Error<Nodo, ICollection<NodoDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<NodoDTO>> UpdateAsync(NodoDTO request, int id)
    {
        try
        {
            if (id == 0)
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.InvalidId);
            }

            Nodo nodo = await _nodoRepository.FindAsync(id);

            if (nodo == null)
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.NotFound);
            }

            if (nodo.Origen?.Id != request.OrigenId)
            {
                Parada nodoDtoOrigen = await _paradaRepository.GetAsync(new ParadaFilter() { Id = request.OrigenId });

                if (await _paradaRepository.ExistsAsync(new ParadaFilter() { Id = request.OrigenId }))
                {
                    nodo.Origen = nodoDtoOrigen;
                }
                else
                {
                    return KeyError<Nodo, NodoDTO>(nameof(request.OrigenId), ErrorMessage.InvalidId);
                }
            }

            if (nodo.Destino?.Id != request.DestinoId)
            {
                Parada nodoDtoDestino = await _paradaRepository.GetAsync(new ParadaFilter() { Id = request.DestinoId });

                if (await _paradaRepository.ExistsAsync(new ParadaFilter() { Id = request.DestinoId }))
                {
                    nodo.Destino = nodoDtoDestino;
                }
            }

            nodo.Demora = request.Demora;
            nodo.Precio = request.Precio;

            if (!await _nodoRepository.UpdateAsync(nodo))
            {
                return Error<Nodo, NodoDTO>(ErrorMessage.CouldNotUpdate);
            }

            return Ok<Nodo, NodoDTO>(_mapper.Map<NodoDTO>(nodo), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Nodo, NodoDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public Task<WebResult<NodoDTO>> ValidateAsync(NodoDTO request)
    {
        throw new NotImplementedException();
    }

}
