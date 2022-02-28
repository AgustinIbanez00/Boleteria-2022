using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;
using EntityFramework.Exceptions.Common;
using static BoleteriaOnline.Core.Utils.WebResponse;

namespace BoleteriaOnline.Web.Services;
public class ParadaService : IParadaService
{
    private readonly IMapper _mapper;
    private readonly IParadaRepository _paradaRepository;

    public ParadaService(IMapper mapper, IParadaRepository paradaRepository)
    {
        _mapper = mapper;
        _paradaRepository = paradaRepository;
    }

    public async Task<WebResult<PaginatedList<ParadaDTO>>> AllAsync(Pagination parameters)
    {
        try
        {
            PaginatedList<Parada> paradas = await _paradaRepository.GetAllAsync(parameters);
            return Ok(_mapper.MapPaginatedList<Parada, ParadaDTO>(paradas.AsQueryable(), parameters));
        }
        catch (Exception ex)
        {
            return Error<Parada, PaginatedList<ParadaDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> CreateAsync(ParadaDTO request)
    {
        try
        {
            var parada = _mapper.Map<Parada>(request);
            if (!await _paradaRepository.CreateAsync(parada))
                return Error<Parada, ParadaDTO>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ParadaDTO>(parada);
            return Ok<Parada, ParadaDTO>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Parada, ParadaDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> DeleteAsync(long id)
    {
        try
        {
            var parada = await _paradaRepository.GetAsync(id);
            if (parada == null)
                return Error<Parada, ParadaDTO>(ErrorMessage.NotFound);

            if (!await _paradaRepository.DeleteAsync(parada))
                return Error<Parada, ParadaDTO>(ErrorMessage.CouldNotDelete);

            return Ok<Parada, ParadaDTO>(_mapper.Map<ParadaDTO>(parada), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> GetAsync(long id)
    {
        try
        {
            var parada = await _paradaRepository.GetAsync(id);

            if (parada == null)
                return Error<Parada, ParadaDTO>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ParadaDTO>(parada));
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> UpdateAsync(ParadaDTO request, long id)
    {
        try
        {
            if (id == 0)
                return Error<Parada, ParadaDTO>(ErrorMessage.InvalidId);

            var destino = await _paradaRepository.GetAsync(id);

            if (destino == null)
                return Error<Parada, ParadaDTO>(ErrorMessage.NotFound);

            destino.Nombre = request.Nombre;
            destino.Estado = request.Estado;

            if (!await _paradaRepository.UpdateAsync(destino))
                return Error<Parada, ParadaDTO>(ErrorMessage.CouldNotUpdate);

            return Ok<Parada, ParadaDTO>(_mapper.Map<ParadaDTO>(destino), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Parada, ParadaDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
}
