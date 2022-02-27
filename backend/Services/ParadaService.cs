using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
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

    public async Task<WebResult<ParadaDTO>> CreateParadaAsync(ParadaDTO request)
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
    public async Task<WebResult<ParadaDTO>> DeleteParadaAsync(long id)
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
    public async Task<WebResult<ParadaDTO>> GetParadaAsync(long id)
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
    public async Task<WebResult<ICollection<ParadaDTO>>> GetParadasAsync()
    {
        try
        {
            var paradas = await _paradaRepository.GetAllAsync();

            var paradasDTO = new List<ParadaDTO>();

            foreach (var parada in paradas)
            {
                paradasDTO.Add(_mapper.Map<ParadaDTO>(parada));
            }
            return Ok<ICollection<ParadaDTO>>(paradasDTO);
        }
        catch (Exception ex)
        {
            return Error<Parada, ICollection<ParadaDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> UpdateParadaAsync(ParadaDTO destinoDto, long id)
    {
        try
        {
            if (id == 0)
                return Error<Parada, ParadaDTO>(ErrorMessage.InvalidId);

            var destino = await _paradaRepository.GetAsync(id);

            if (destino == null)
                return Error<Parada, ParadaDTO>(ErrorMessage.NotFound);

            destino.Nombre = destinoDto.Nombre;

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
