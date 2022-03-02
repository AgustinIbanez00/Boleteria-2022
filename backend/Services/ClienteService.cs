using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data.Filters;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using EntityFramework.Exceptions.Common;
using static BoleteriaOnline.Core.Utils.WebResponse;

namespace BoleteriaOnline.Web.Services;
public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IClienteRepository _clienteRepository;
    private readonly IPaisRepository _paisRepository;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository, IPaisRepository paisRepository)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
        this._paisRepository = paisRepository;
    }

    public async Task<WebResultList<ClienteDTO>> AllAsync(ClienteFilter parameters)
    {
        try
        {
            PaginatedList<Cliente> clientes = await _clienteRepository.GetAllPaginatedAsync(parameters);

            var clientesDto = new List<ClienteDTO>();

            foreach (var cliente in clientes)
            {
                clientesDto.Add(_mapper.Map<ClienteDTO>(cliente));
            }
            return List(clientesDto, Pagination.Page(clientes.TotalItems, parameters.Pagina, parameters.RecordsPorPagina));
        }
        catch (Exception ex)
        {
            return ErrorList<ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteDTO>> CreateAsync(ClienteDTO request)
    {
        try
        {
            var cliente = _mapper.Map<Cliente>(request);
            if (!await _clienteRepository.CreateAsync(cliente))
                return Error<Cliente, ClienteDTO>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ClienteDTO>(cliente);
            return Ok(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<ClienteDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteDTO>> DeleteAsync(ClienteFilter filter)
    {
        try
        {
            var cliente = await _clienteRepository.GetAsync(filter);
            if (cliente == null)
                return Error<ClienteDTO>(ErrorMessage.NotFound);

            if (!await _clienteRepository.DeleteAsync(cliente))
                return Error<ClienteDTO>(ErrorMessage.CouldNotDelete);

            return Ok(_mapper.Map<ClienteDTO>(cliente), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteDTO>> GetAsync(ClienteFilter filter)
    {
        try
        {
            var cliente = await _clienteRepository.GetAsync(filter);

            if (cliente == null)
                return Error<ClienteDTO>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }
        catch (Exception ex)
        {
            return Error<ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteDTO>> UpdateAsync(ClienteDTO request, ClienteFilter filter)
    {
        try
        {
            if (filter.Dni == 0)
                return Error<ClienteDTO>(ErrorMessage.InvalidId);

            var cliente = await _clienteRepository.GetAsync(filter);

            if (cliente == null)
                return Error<ClienteDTO>(ErrorMessage.NotFound);

            cliente.Nombre = request.Nombre;
            cliente.FechaNac = request.FechaNacimiento;
            cliente.Genero = request.Genero;
            cliente.Estado = request.Estado;
            cliente.NacionalidadId = request.NacionalidadId;

            if (!await _clienteRepository.UpdateAsync(cliente))
                return Error<ClienteDTO>(ErrorMessage.CouldNotUpdate);

            return Ok(_mapper.Map<ClienteDTO>(cliente), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<ClienteDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteDTO>> ValidateAsync(ClienteDTO request)
    {
        if (!await _paisRepository.ExistsAsync(new PaisFilter() { Id = request.NacionalidadId }))
            return KeyError<ClienteDTO>(nameof(request.NacionalidadId), ErrorMessage.NotFound);

        return Ok<ClienteDTO>();
    }
}
