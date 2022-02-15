using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IDistribucionRepository
{
    Task<ICollection<Distribucion>> GetDistribucionesAsync();
    Task<Distribucion> GetDistribucionAsync(long id);
    Task<bool> ExistsDistribucionAsync(long id);
    Task<bool> CreateDistribucionAsync(Distribucion distribucion);
    Task<bool> DeleteDistribucionAsync(Distribucion distribucion);
    Task<bool> DeleteDistribucionAsync(long id);
    Task<bool> UpdateDistribucionAsync(Distribucion distribucion);
    Task<bool> RemoveAllFilas(Distribucion distribucion);
    Task<bool> Save();
}
