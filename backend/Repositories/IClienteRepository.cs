using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IClienteRepository
{
    Task<ICollection<Cliente>> GetClientesAsync();
    Task<Cliente> GetClienteAsync(long id);
    Task<bool> ExistsClienteAsync(long id);
    Task<bool> CreateClienteAsync(Cliente cliente);
    Task<bool> DeleteClienteAsync(Cliente cliente);
    Task<bool> DeleteClienteAsync(long id);
    Task<bool> UpdateClienteAsync(Cliente cliente);
    Task<bool> Save();
}
