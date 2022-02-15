using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IDestinoRepository
{
    Task<ICollection<Destino>> GetDestinosAsync();
    Task<Destino> GetDestinoAsync(long id);
    Task<bool> ExistsDestinoAsync(long id);
    Task<bool> CreateDestinoAsync(Destino destino);
    Task<bool> DeleteDestinoAsync(Destino destino);
    Task<bool> DeleteDestinoAsync(long id);
    Task<bool> UpdateDestinoAsync(Destino destino);
    Task<bool> Save();
}
