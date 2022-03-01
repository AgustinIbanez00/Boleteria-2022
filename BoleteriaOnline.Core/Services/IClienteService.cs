using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface IClienteService
{
    Task<WebResult<ICollection<ClienteDTO>>> GetClientesAsync();
    Task<WebResult<ClienteDTO>> GetClienteAsync(long id);
    Task<WebResult<ClienteDTO>> CreateClienteAsync(ClienteDTO clienteDto);
    Task<WebResult<ClienteDTO>> UpdateClienteAsync(ClienteDTO clienteDto);
    Task<WebResult<ClienteDTO>> DeleteClienteAsync(long id);
}
