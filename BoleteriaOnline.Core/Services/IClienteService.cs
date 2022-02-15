using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface IClienteService
{
    Task<WebResult<ICollection<ClienteResponse>>> GetClientesAsync();
    Task<WebResult<ClienteResponse>> GetClienteAsync(long id);
    Task<WebResult<ClienteResponse>> CreateClienteAsync(ClienteRequest clienteDto);
    Task<WebResult<ClienteResponse>> UpdateClienteAsync(ClienteRequest clienteDto);
    Task<WebResult<ClienteResponse>> DeleteClienteAsync(long id);
}
