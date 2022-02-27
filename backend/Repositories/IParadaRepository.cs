using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IParadaRepository
{
    Task<ICollection<Parada>> GetAllAsync();
    Task<Parada> GetAsync(long id);
    Task<bool> ExistsAsync(long id);
    Task<bool> CreateAsync(Parada destino);
    Task<bool> DeleteAsync(Parada destino);
    Task<bool> DeleteAsync(long id);
    Task<bool> UpdateAsync(Parada destino);
    Task<bool> Save();
}
