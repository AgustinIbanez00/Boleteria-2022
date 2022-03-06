using AutoMapper;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
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

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
    }

    public async Task<WebResult<ICollection<ClienteDTO>>> AllAsync(ClienteFilter filter)
    {
        try
        {
            var clientes = await _clienteRepository.GetAllAsync(filter);

            var clientesDto = new List<ClienteDTO>();

            foreach (var cliente in clientes)
            {
                clientesDto.Add(_mapper.Map<ClienteDTO>(cliente));
            }

            return Ok<ICollection<ClienteDTO>>(clientesDto);
        }
        catch (Exception ex)
        {
            return Error<ICollection<ClienteDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResultList<ClienteDTO>> AllPaginatedAsync(ClienteFilter filter)
    {
        try
        {
            PaginatedList<Cliente> clientes = await _clienteRepository.GetAllPaginatedAsync(filter);

            var clientesDto = new List<ClienteDTO>();

            foreach (var cliente in clientes)
            {
                clientesDto.Add(_mapper.Map<ClienteDTO>(cliente));
            }

            return List(clientesDto, Pagination.Page(clientes.TotalItems, filter.Pagina, filter.RecordsPorPagina));
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
            if (request.Dni <= 0)
                return Error<ClienteDTO>(ErrorMessage.InvalidId);

            if (await _clienteRepository.ExistsAsync(new ClienteFilter() { Dni = request.Dni }))
                return Error<ClienteDTO>(ErrorMessage.AlreadyExists);

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
        catch (ReferenceConstraintException)
        {
            return Error<ClienteDTO>(ErrorMessage.CouldNotDeleteReferenced);
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

    public async Task<WebResult<ClienteDTO>> UpdateAsync(ClienteDTO request, long id)
    {
        try
        {
            if (id <= 0)
                return Error<ClienteDTO>(ErrorMessage.InvalidId);

            var cliente = await _clienteRepository.FindAsync(id);

            if (cliente == null)
                return Error<ClienteDTO>(ErrorMessage.NotFound);

            cliente.Nombre = request.Nombre;

            DateTime fechaNac;

            if (!DateTime.TryParse(request.FechaNacimiento, out fechaNac))
                return KeyError<ClienteDTO>(nameof(request.FechaNacimiento), "El formato de fecha es inválido.");

            cliente.FechaNac = Convert.ToDateTime(request.FechaNacimiento);
            cliente.Genero = request.Genero;
            cliente.Estado = request.Estado;

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

    public Task<WebResult<ClienteDTO>> ValidateAsync(ClienteDTO request)
    {
        return Task.FromResult(Ok<ClienteDTO>());
    }
}
