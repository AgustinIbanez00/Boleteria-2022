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
    private readonly IPaisRepository _paisRepository;
    private readonly IProvinciaRepository _provinciaRepository;

    public ParadaService(IMapper mapper, IParadaRepository paradaRepository, IPaisRepository paisRepository, IProvinciaRepository provinciaRepository)
    {
        _mapper = mapper;
        _paradaRepository = paradaRepository;
        _paisRepository = paisRepository;
        _provinciaRepository = provinciaRepository;
    }

    public async Task<WebResult<ICollection<ParadaDTO>>> AllAsync(ParadaFilter filter)
    {
        try
        {
            ICollection<Parada> paradas = await _paradaRepository.GetAllAsync(filter);

            List<ParadaDTO> paradasDto = new();

            foreach (Parada parada in paradas)
            {
                paradasDto.Add(_mapper.Map<ParadaDTO>(parada));
            }

            return Ok<ICollection<ParadaDTO>>(paradasDto);
        }
        catch (Exception ex)
        {
            return Error<ICollection<ParadaDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResultList<ParadaDTO>> AllPaginatedAsync(ParadaFilter filter)
    {
        try
        {
            PaginatedList<Parada> paradas = await _paradaRepository.GetAllPaginatedAsync(filter);

            List<ParadaDTO> paradasDto = new();

            foreach (Parada parada in paradas)
            {
                paradasDto.Add(_mapper.Map<ParadaDTO>(parada));
            }

            return List(paradasDto, Pagination.Page(paradas.TotalItems, filter.Pagina, filter.RecordsPorPagina));
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
            if (!await _paisRepository.ExistsAsync(new PaisFilter() { Id = request.PaisId }))
            {
                return KeyError<PaisDTO, ParadaDTO>(nameof(request.PaisId), ErrorMessage.NotFound);
            }

            if (!await _provinciaRepository.ExistsAsync(new ProvinciaFilter() { Id = request.ProvinciaId }))
            {
                return KeyError<ProvinciaDTO, ParadaDTO>(nameof(request.ProvinciaId), ErrorMessage.NotFound);
            }

            Parada parada = _mapper.Map<Parada>(request);

            if (!await _paradaRepository.CreateAsync(parada))
            {
                return Error<Parada, ParadaDTO>(ErrorMessage.CouldNotCreate);
            }

            ParadaDTO dto = _mapper.Map<ParadaDTO>(parada);
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

    public async Task<WebResult<ParadaDTO>> DeleteAsync(ParadaFilter filter)
    {
        try
        {
            Parada parada = await _paradaRepository.GetAsync(filter);
            if (parada == null)
            {
                return Error<ParadaDTO>(ErrorMessage.NotFound);
            }

            if (!await _paradaRepository.DeleteAsync(parada))
            {
                return Error<ParadaDTO>(ErrorMessage.CouldNotDelete);
            }

            return Ok(_mapper.Map<ParadaDTO>(parada), SuccessMessage.Deleted);
        }
        catch (ReferenceConstraintException)
        {
            return Error<ParadaDTO>(ErrorMessage.CouldNotDeleteReferenced);
        }
        catch (Exception ex)
        {
            return Error<ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> GetAsync(ParadaFilter filter)
    {
        try
        {
            Parada parada = await _paradaRepository.GetAsync(filter);

            if (parada == null)
            {
                return Error<ParadaDTO>(ErrorMessage.NotFound);
            }

            return Ok(_mapper.Map<ParadaDTO>(parada));
        }
        catch (Exception ex)
        {
            return Error<ParadaDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ParadaDTO>> UpdateAsync(ParadaDTO request, int id)
    {
        try
        {
            if (id <= 0)
            {
                return Error<ParadaDTO>(ErrorMessage.InvalidId);
            }

            if (!await _paisRepository.ExistsAsync(new PaisFilter() { Id = request.PaisId }))
            {
                return KeyError<PaisDTO, ParadaDTO>(nameof(request.PaisId), ErrorMessage.NotFound);
            }

            if (!await _provinciaRepository.ExistsAsync(new ProvinciaFilter() { Id = request.ProvinciaId }))
            {
                return KeyError<ProvinciaDTO, ParadaDTO>(nameof(request.ProvinciaId), ErrorMessage.NotFound);
            }

            Parada destino = await _paradaRepository.FindAsync(id);

            if (destino == null)
            {
                return Error<ParadaDTO>(ErrorMessage.NotFound);
            }

            destino.Nombre = request.Nombre;
            destino.Estado = request.Estado;

            Pais pais = await _paisRepository.GetAsync(new PaisFilter() { Id = request.PaisId });
            Provincia provincia = await _provinciaRepository.GetAsync(new ProvinciaFilter() { Id = request.ProvinciaId });

            destino.Pais = pais;
            destino.Provincia = provincia;

            if (!await _paradaRepository.UpdateAsync(destino))
            {
                return Error<ParadaDTO>(ErrorMessage.CouldNotUpdate);
            }

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
