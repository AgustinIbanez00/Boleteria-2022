using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using EntityFramework.Exceptions.Common;

namespace BoleteriaOnline.Web.Services;
using static WebResponse;
public class NodoService : INodoService
{
    private readonly IMapper _mapper;
    private readonly INodoRepository _nodoRepository;
    private readonly IDestinoRepository _destinoRepository;

    public NodoService(IMapper mapper, INodoRepository nodoRepository, IDestinoRepository destinoRepository)
    {
        _mapper = mapper;
        _nodoRepository = nodoRepository;
        _destinoRepository = destinoRepository;
    }

    public async Task<WebResult<NodoResponse>> CreateNodoAsync(NodoRequest nodoDto)
    {
        try
        {
            var nodo = _mapper.Map<Nodo>(nodoDto);

            Destino nodoDtoOrigen = await _destinoRepository.GetDestinoAsync(nodoDto.OrigenId);

            if (nodoDtoOrigen != null)
                nodo.Origen = nodoDtoOrigen;
            else
                return KeyError<Destino, NodoResponse>(nameof(nodoDto.OrigenId), ErrorMessage.NotFound);
            
            Destino nodoDtoDestino = await _destinoRepository.GetDestinoAsync(nodoDto.DestinoId);

            if (nodoDtoDestino != null)
                nodo.Destino = nodoDtoDestino;
            else
                return KeyError<Destino, NodoResponse>(nameof(nodoDto.DestinoId), ErrorMessage.NotFound);

            if (nodo.Origen == nodo.Destino)
                return Error<NodoResponse>("El nodo origen no puede ser igual al nodo destino.");

            if (!await _nodoRepository.CreateNodoAsync(nodo))
                return Error<Nodo, NodoResponse>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<NodoResponse>(nodo);
            return Ok<Nodo, NodoResponse>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Nodo, NodoResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<NodoResponse>> DeleteNodoAsync(long id)
    {
        try
        {
            var nodo = await _nodoRepository.GetNodoAsync(id);
            if (nodo == null)
                return Error<Nodo, NodoResponse>(ErrorMessage.NotFound);

            if (!await _nodoRepository.DeleteNodoAsync(nodo))
                return Error<Nodo, NodoResponse>(ErrorMessage.CouldNotDelete);

            return Ok<Nodo, NodoResponse>(_mapper.Map<NodoResponse>(nodo), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<NodoResponse>> GetNodoAsync(long id)
    {
        try
        {
            var nodo = await _nodoRepository.GetNodoAsync(id);

            if (nodo == null)
                return Error<Nodo, NodoResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<NodoResponse>(nodo));
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ICollection<NodoResponse>>> GetNodosAsync()
    {
        try
        {
            var nodos = await _nodoRepository.GetNodosAsync();

            var nodosDto = new List<NodoResponse>();

            foreach (var Nodo in nodos)
            {
                nodosDto.Add(_mapper.Map<NodoResponse>(Nodo));
            }
            return Ok<ICollection<NodoResponse>>(nodosDto);
        }
        catch (Exception ex)
        {
            return Error<Nodo, ICollection<NodoResponse>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<NodoResponse>> UpdateNodoAsync(NodoRequest nodoDto)
    {
        try
        {
            if (nodoDto.Id == 0)
                return Error<Nodo, NodoResponse>(ErrorMessage.InvalidId);

            Nodo nodo = await _nodoRepository.GetNodoAsync(nodoDto.Id);

            if (nodo == null)
                return Error<Nodo, NodoResponse>(ErrorMessage.NotFound);

            if(nodo.Origen?.Id != nodoDto.OrigenId)
            {
                Destino nodoDtoOrigen = await _destinoRepository.GetDestinoAsync(nodoDto.OrigenId);

                if (await _destinoRepository.ExistsDestinoAsync(nodoDto.OrigenId))
                    nodo.Origen = nodoDtoOrigen;
                else
                    return KeyError<Nodo, NodoResponse>(nameof(nodoDto.OrigenId), ErrorMessage.InvalidId);
            }

            if (nodo.Destino?.Id != nodoDto.DestinoId)
            {
                Destino nodoDtoDestino = await _destinoRepository.GetDestinoAsync(nodoDto.DestinoId);

                if (await _destinoRepository.ExistsDestinoAsync(nodoDto.DestinoId))
                    nodo.Destino = nodoDtoDestino;
            }

            nodo.Demora = nodoDto.Demora;
            nodo.Precio = nodoDto.Precio;

            if (!await _nodoRepository.UpdateNodoAsync(nodo))
                return Error<Nodo, NodoResponse>(ErrorMessage.CouldNotUpdate);

            return Ok<Nodo, NodoResponse>(_mapper.Map<NodoResponse>(nodo), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Nodo, NodoResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Nodo, NodoResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
}
