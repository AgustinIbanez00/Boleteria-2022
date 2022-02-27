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
public class ParadaService : IParadaService
{
    private readonly IMapper _mapper;
    private readonly IParadaRepository _paradaRepository;

    public ParadaService(IMapper mapper, IParadaRepository paradaRepository)
    {
        _mapper = mapper;
        _paradaRepository = paradaRepository;
    }

    public async Task<WebResult<ParadaResponse>> CreateParadaAsync(ParadaRequest request)
    {
        try
        {
            var parada = _mapper.Map<Parada>(request);
            if (!await _paradaRepository.CreateAsync(parada))
                return Error<Parada, ParadaResponse>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ParadaResponse>(parada);
            return Ok<Parada, ParadaResponse>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Parada, ParadaResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ParadaResponse>> DeleteParadaAsync(long id)
    {
        try
        {
            var parada = await _paradaRepository.GetAsync(id);
            if (parada == null)
                return Error<Parada, ParadaResponse>(ErrorMessage.NotFound);

            if (!await _paradaRepository.DeleteAsync(parada))
                return Error<Parada, ParadaResponse>(ErrorMessage.CouldNotDelete);

            return Ok<Parada, ParadaResponse>(_mapper.Map<ParadaResponse>(parada), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ParadaResponse>> GetParadaAsync(long id)
    {
        try
        {
            var parada = await _paradaRepository.GetAsync(id);

            if (parada == null)
                return Error<Parada, ParadaResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ParadaResponse>(parada));
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ICollection<ParadaResponse>>> GetParadasAsync()
    {
        try
        {
            var paradas = await _paradaRepository.GetAllAsync();

            var paradasDTO = new List<ParadaResponse>();

            foreach (var parada in paradas)
            {
                paradasDTO.Add(_mapper.Map<ParadaResponse>(parada));
            }
            return Ok<ICollection<ParadaResponse>>(paradasDTO);
        }
        catch (Exception ex)
        {
            return Error<Parada, ICollection<ParadaResponse>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaResponse>> UpdateParadaAsync(ParadaRequest destinoDto, long id)
    {
        try
        {
            if (id == 0)
                return Error<Parada, ParadaResponse>(ErrorMessage.InvalidId);

            var destino = await _paradaRepository.GetAsync(id);

            if (destino == null)
                return Error<Parada, ParadaResponse>(ErrorMessage.NotFound);

            destino.Nombre = destinoDto.Nombre;

            if (!await _paradaRepository.UpdateAsync(destino))
                return Error<Parada, ParadaResponse>(ErrorMessage.CouldNotUpdate);

            return Ok<Parada, ParadaResponse>(_mapper.Map<ParadaResponse>(destino), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Parada, ParadaResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Parada, ParadaResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
}
