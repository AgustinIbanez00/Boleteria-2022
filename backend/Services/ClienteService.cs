using AutoMapper;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.Extensions.Response;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
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

    public async Task<WebResult<ClienteDTO>> CreateClienteAsync(ClienteDTO clienteDto)
    {
        try
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            if (!await _clienteRepository.CreateClienteAsync(cliente))
                return Error<Cliente, ClienteDTO>(ErrorMessage.CouldNotCreate);

            var dto = _mapper.Map<ClienteDTO>(cliente);
            return Ok<Cliente, ClienteDTO>(dto, SuccessMessage.Created);
        }
        catch (UniqueConstraintException)
        {
            return Error<Cliente, ClienteDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ClienteDTO>> DeleteClienteAsync(long id)
    {
        try
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);
            if (cliente == null)
                return Error<Cliente, ClienteDTO>(ErrorMessage.NotFound);

            if (cliente.Estado == Estado.Baja)
                return Error<Cliente, ClienteDTO>(ErrorMessage.AlreadyDeleted);

            if (!await _clienteRepository.DeleteClienteAsync(cliente))
                return Error<Cliente, ClienteDTO>(ErrorMessage.CouldNotDelete);

            return Ok<Cliente, ClienteDTO>(_mapper.Map<ClienteDTO>(cliente), SuccessMessage.Deleted);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ClienteDTO>> GetClienteAsync(long id)
    {
        try
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);

            if (cliente == null)
                return Error<Cliente, ClienteDTO>(ErrorMessage.NotFound);

            return Ok(_mapper.Map<ClienteDTO>(cliente));
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
    public async Task<WebResult<ICollection<ClienteDTO>>> GetClientesAsync()
    {
        try
        {
            var clientes = await _clienteRepository.GetClientesAsync();

            var clientesDto = new List<ClienteDTO>();

            foreach (var Cliente in clientes)
            {
                clientesDto.Add(_mapper.Map<ClienteDTO>(Cliente));
            }
            return Ok<ICollection<ClienteDTO>>(clientesDto);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ICollection<ClienteDTO>>(ErrorMessage.Generic, ex.Message);
        }
    }

    public async Task<WebResult<ClienteDTO>> UpdateClienteAsync(ClienteDTO clienteDto)
    {
        try
        {
            if (clienteDto.Dni == 0)
                return Error<Cliente, ClienteDTO>(ErrorMessage.InvalidId);

            var cliente = await _clienteRepository.GetClienteAsync(clienteDto.Dni);

            if (cliente == null)
                return Error<Cliente, ClienteDTO>(ErrorMessage.NotFound);

            cliente.Nombre = clienteDto.Nombre;
            cliente.FechaNac = clienteDto.FechaNacimiento;
            cliente.Nacionalidad = clienteDto.Nacionalidad;
            cliente.Genero = clienteDto.Genero;

            if (!await _clienteRepository.UpdateClienteAsync(cliente))
                return Error<Cliente, ClienteDTO>(ErrorMessage.CouldNotUpdate);

            return Ok<Cliente, ClienteDTO>(_mapper.Map<ClienteDTO>(cliente), SuccessMessage.Modified);
        }
        catch (UniqueConstraintException)
        {
            return Error<Cliente, ClienteDTO>(ErrorMessage.AlreadyExists);
        }
        catch (Exception ex)
        {
            return Error<Cliente, ClienteDTO>(ErrorMessage.Generic, ex.Message);
        }
    }
}
