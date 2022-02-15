using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface ICeldaRepository
{
    /*
    Task<ICollection<Celda>> GetCeldasAsync();
    Task<Celda> GetCeldaAsync(long id);
    Task<bool> ExistsCeldaAsync(long id);
    Task<bool> CreateCeldaAsync(Celda celda);
    Task<bool> DeleteCeldaAsync(Celda celda);
    Task<bool> DeleteCeldaAsync(long id);
    */
    Task<bool> UpdateCeldaAsync(Celda celda);
    Task<bool> Save();
}
