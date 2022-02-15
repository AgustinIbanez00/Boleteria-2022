using AutoMapper;
using BoleteriaOnline.Core.Data.Enums;
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
public class ClienteService : IClienteService
{
    private readonly IMapper _mapper;
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IMapper mapper, IClienteRepository clienteRepository)
    {
        _mapper = mapper;
        _clienteRepository = clienteRepository;
    }

    public async Task<WebResult<ClienteResponse>> CreateClienteAsync(ClienteRequest clienteDto)
    {
        try
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            if (!await _clienteRepository.CreateClienteAsync(cliente))
                return Error<Cliente, ClienteResponse>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ClienteResponse>(cliente);
            return Ok<Cliente, ClienteResponse>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Cliente, ClienteResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ClienteResponse>> DeleteClienteAsync(long id)
    {
        try
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);
            if (cliente == null)
                return Error<Cliente, ClienteResponse>(ErrorMessage.NotFound);

            if (cliente.Estado == Estado.Baja)
                return Error<Cliente, ClienteResponse>(ErrorMessage.AlreadyDeleted);

            if (!await _clienteRepository.DeleteClienteAsync(cliente))
                return Error<Cliente, ClienteResponse>(ErrorMessage.CouldNotDelete);

            return Ok<Cliente, ClienteResponse>(_mapper.Map<ClienteResponse>(cliente), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ClienteResponse>> GetClienteAsync(long id)
    {
        try
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);

            if (cliente == null)
                return Error<Cliente, ClienteResponse>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ClienteResponse>(cliente));
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ICollection<ClienteResponse>>> GetClientesAsync()
    {
        try
        {
            var clientes = await _clienteRepository.GetClientesAsync();

            var clientesDto = new List<ClienteResponse>();

            foreach (var Cliente in clientes)
            {
                clientesDto.Add(_mapper.Map<ClienteResponse>(Cliente));
            }
            return Ok<ICollection<ClienteResponse>>(clientesDto);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ICollection<ClienteResponse>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteResponse>> UpdateClienteAsync(ClienteRequest clienteDto)
    {
        try
        {
            if (clienteDto.Dni == 0)
                return Error<Cliente, ClienteResponse>(ErrorMessage.InvalidId);

            var cliente = await _clienteRepository.GetClienteAsync(clienteDto.Dni);

            if (cliente == null)
                return Error<Cliente, ClienteResponse>(ErrorMessage.NotFound);

            cliente.Nombre = clienteDto.Nombre;
            cliente.FechaNac = clienteDto.FechaNacimiento;
            cliente.Nacionalidad = clienteDto.Nacionalidad;
            cliente.Genero = clienteDto.Genero;

            if (!await _clienteRepository.UpdateClienteAsync(cliente))
                return Error<Cliente, ClienteResponse>(ErrorMessage.CouldNotUpdate);

            return Ok<Cliente, ClienteResponse>(_mapper.Map<ClienteResponse>(cliente), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Cliente, ClienteResponse>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteResponse>(ErrorMessage.Generic, ex.Message);
        }
    }
}
