using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IFilaRepository
{
    /*
    Task<ICollection<Fila>> GetFilasAsync();
    Task<Fila> GetFilaAsync(long id);
    Task<bool> ExistsFilaAsync(long id);
    Task<bool> CreateFilaAsync(Fila fila);
    Task<bool> DeleteFilaAsync(Fila fila);
    Task<bool> DeleteFilaAsync(long id);
    */
    Task<bool> UpdateFilaAsync(Fila fila);
    Task<bool> Save();
}
