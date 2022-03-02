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

    public async Task<WebResultList<ParadaDTO>> AllAsync(ParadaFilter parameters)
    {
        try
        {
            PaginatedList<Parada> paradas = await _paradaRepository.GetAllPaginatedAsync(parameters);

            var paradasDto = new List<ParadaDTO>();

            foreach (var parada in paradas)
            {
                paradasDto.Add(_mapper.Map<ParadaDTO>(parada));
            }
            return List(paradasDto, Pagination.Page(paradas.TotalItems, parameters.Pagina, parameters.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<ParadaDTO>(ErrorMessage.Generic, ex.Message);
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
            return Ok(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<ParadaDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public Task<WebResult<ParadaDTO>> DeleteAsync(ParadaFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<WebResult<ParadaDTO>> GetAsync(ParadaFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<WebResult<ParadaDTO>> UpdateAsync(ParadaDTO request, int id)
    {
        try
        {
            if (id == 0)
                return Error<ParadaDTO>(ErrorMessage.InvalidId);

            var destino = await _paradaRepository.FindAsync(id);

            if (destino == null)
                return Error<ParadaDTO>(ErrorMessage.NotFound);

            destino.Nombre = request.Nombre;
            destino.Estado = request.Estado;

            if (!await _paradaRepository.UpdateAsync(destino))
                return Error<ParadaDTO>(ErrorMessage.CouldNotUpdate);

            return Ok(_mapper.Map<ParadaDTO>(destino), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<ParadaDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public Task<WebResult<ParadaDTO>> ValidateAsync(ParadaDTO request)
    {
        throw new NotImplementedException();
    }
}
