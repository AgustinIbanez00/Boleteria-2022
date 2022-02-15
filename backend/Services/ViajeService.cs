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
public class ViajeService : IViajeService
{
    private readonly IMapper _mapper;
    private readonly IViajeRepository _viajeRepository;
    private readonly IDistribucionRepository _distribucionRepository
        ;

    public ViajeService(IMapper mapper, IViajeRepository viajeRepository, IDistribucionRepository distribucionRepository)
    {
        _mapper = mapper;
        _viajeRepository = viajeRepository;
        _distribucionRepository = distribucionRepository;
    }

    public async Task<WebResult<ViajeResponse>> CreateViajeAsync(ViajeRequest viajeDto)
    {
        try
        {
            if (viajeDto.Horarios.Count == 0)
                return Error<Horario, ViajeResponse>(ErrorMessage.EmptyList);

            foreach (var horario in viajeDto.Horarios)
            {
                if (!await _distribucionRepository.ExistsDistribucionAsync(horario.DistribucionId))
                    return Error<Distribucion, ViajeResponse>(ErrorMessage.NotFound);
            }

            Viaje viaje = _mapper.Map<Viaje>(viajeDto);

            foreach (var horario in viaje.Horarios)
            {
                horario.Lunes = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Monday);
                horario.Martes = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Tuesday);
                horario.Miercoles = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Wednesday);
                horario.Jueves = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Thursday);
                horario.Viernes = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Friday);
                horario.Sabado = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Saturday);
                horario.Domingo = viajeDto.Horarios[viaje.Horarios.IndexOf(horario)].Dias.Contains(DayOfWeek.Sunday);
            }

            if (!await _viajeRepository.CreateViajeAsync(viaje))
                return Error<Viaje, ViajeResponse>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ViajeResponse>(viaje);
            return Ok<Viaje, ViajeResponse>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Viaje, ViajeResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ViajeResponse>> DeleteViajeAsync(long id)
    {
        try
        {
            var viaje = await _viajeRepository.GetViajeAsync(id);
            if (viaje == null)
                return Error<Viaje, ViajeResponse>(ErrorMessage.NotFound);

            if (!await _viajeRepository.DeleteViajeAsync(viaje))
                return Error<Viaje, ViajeResponse>(ErrorMessage.CouldNotDelete);

            return Ok<Viaje, ViajeResponse>(_mapper.Map<ViajeResponse>(viaje), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ViajeResponse>> GetViajeAsync(long id)
    {
        try
        {
            var viaje = await _viajeRepository.GetViajeAsync(id);

            if (viaje == null)
                return Error<Viaje, ViajeResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ViajeResponse>(viaje));
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ICollection<ViajeResponse>>> GetViajesAsync()
    {
        try
        {
            var viajes = await _viajeRepository.GetViajesAsync();

            var viajesDto = new List<ViajeResponse>();

            foreach (var Viaje in viajes)
            {
                viajesDto.Add(_mapper.Map<ViajeResponse>(Viaje));
            }
            return Ok<ICollection<ViajeResponse>>(viajesDto);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ICollection<ViajeResponse>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ViajeResponse>> UpdateViajeAsync(ViajeUpdateRequest viajeDto)
    {
        try
        {
            if (viajeDto.Id == 0)
                return Error<Viaje, ViajeResponse>(ErrorMessage.InvalidId);

            var viaje = await _viajeRepository.GetViajeAsync(viajeDto.Id);

            if (viaje == null)
                return Error<Viaje, ViajeResponse>(ErrorMessage.NotFound);

            viaje.Nombre = viajeDto.Nombre;
            //viaje.Horarios = viajeDto.Horarios;
            //viaje.Nodos = viajeDto.Nodos;

            if (!await _viajeRepository.UpdateViajeAsync(viaje))
                return Error<Viaje, ViajeResponse>(ErrorMessage.CouldNotUpdate);

            return Ok<Viaje, ViajeResponse>(_mapper.Map<ViajeResponse>(viaje), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Viaje, ViajeResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Viaje, ViajeResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
}
