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
public class BoletoService : IBoletoService
{
    private readonly IMapper _mapper;
    private readonly IBoletoRepository _boletoRepository;

    public BoletoService(IMapper mapper, IBoletoRepository boletoRepository)
    {
        _mapper = mapper;
        _boletoRepository = boletoRepository;
    }

    public async Task<WebResult<ICollection<BoletoDTO>>> AllAsync(BoletoFilter filter)
    {
        try
        {
            ICollection<Boleto> boletos = await _boletoRepository.GetAllAsync(filter);

            List<BoletoDTO> boletosDto = new();

            foreach (Boleto boleto in boletos)
            {
                boletosDto.Add(_mapper.Map<BoletoDTO>(boleto));
            }

            return Ok<ICollection<BoletoDTO>>(boletosDto);
        }
        catch (Exception ex)
        {
            return Error<ICollection<BoletoDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResultList<BoletoDTO>> AllPaginatedAsync(BoletoFilter filter)
    {
        try
        {
            PaginatedList<Boleto> boletos = await _boletoRepository.GetAllPaginatedAsync(filter);

            List<BoletoDTO> boletosDto = new();

            foreach (Boleto boleto in boletos)
            {
                boletosDto.Add(_mapper.Map<BoletoDTO>(boleto));
            }

            return List(boletosDto, Pagination.Page(boletos.TotalItems, filter.Pagina, filter.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<BoletoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<BoletoDTO>> CreateAsync(BoletoDTO request)
    {
        try
        {
            if (request.Id <= 0)
            {
                return Error<BoletoDTO>(ErrorMessage.InvalidId);
            }

            if (await _boletoRepository.ExistsAsync(new BoletoFilter() { Id = request.Id }))
            {
                return Error<BoletoDTO>(ErrorMessage.AlreadyExists);
            }

            Boleto boleto = _mapper.Map<Boleto>(request);
            if (!await _boletoRepository.CreateAsync(boleto))
            {
                return Error<Boleto, BoletoDTO>(ErrorMessage.CouldNotCreate);
            }

            BoletoDTO dto = _mapper.Map<BoletoDTO>(boleto);
            return Ok(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<BoletoDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<BoletoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<BoletoDTO>> DeleteAsync(BoletoFilter filter)
    {
        try
        {
            Boleto boleto = await _boletoRepository.GetAsync(filter);
            if (boleto == null)
            {
                return Error<BoletoDTO>(ErrorMessage.NotFound);
            }

            if (!await _boletoRepository.DeleteAsync(boleto))
            {
                return Error<BoletoDTO>(ErrorMessage.CouldNotDelete);
            }

            return Ok(_mapper.Map<BoletoDTO>(boleto), SuccessMessage.Deleted);
        }
        catch (ReferenceConstraintException)
        {
            return Error<BoletoDTO>(ErrorMessage.CouldNotDeleteReferenced);
        }
        catch (Exception ex)
        {
            return Error<BoletoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<BoletoDTO>> GetAsync(BoletoFilter filter)
    {
        try
        {
            Boleto boleto = await _boletoRepository.GetAsync(filter);

            if (boleto == null)
            {
                return Error<BoletoDTO>(ErrorMessage.NotFound);
            }

            return Ok(_mapper.Map<BoletoDTO>(boleto));
        }
        catch (Exception ex)
        {
            return Error<BoletoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<BoletoDTO>> UpdateAsync(BoletoDTO request, int id)
    {
        try
        {
            if (id <= 0)
            {
                return Error<BoletoDTO>(ErrorMessage.InvalidId);
            }

            Boleto boleto = await _boletoRepository.FindAsync(id);

            if (boleto == null)
            {
                return Error<BoletoDTO>(ErrorMessage.NotFound);
            }
            /*
boleto.Nombre = request.Nombre;
boleto.FechaNac = request.FechaNacimiento;
boleto.Genero = request.Genero;
boleto.Estado = request.Estado;
*/
            if (!await _boletoRepository.UpdateAsync(boleto))
            {
                return Error<BoletoDTO>(ErrorMessage.CouldNotUpdate);
            }

            return Ok(_mapper.Map<BoletoDTO>(boleto), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<BoletoDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<BoletoDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public Task<WebResult<BoletoDTO>> ValidateAsync(BoletoDTO request)
    {
        return Task.FromResult(Ok<BoletoDTO>());
    }

}
