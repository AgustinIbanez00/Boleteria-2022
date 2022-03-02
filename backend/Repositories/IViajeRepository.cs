using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IViajeRepository : IGenericRepository<int, Viaje, ViajeFilter>
{
    /*
    Task<ICollection<Viaje>> GetViajesAsync();
    Task<Viaje> GetViajeAsync(long id);
    Task<bool> ExistsViajeAsync(long id);
    Task<bool> CreateViajeAsync(Viaje viaje);
    Task<bool> DeleteViajeAsync(Viaje viaje);
    Task<bool> DeleteViajeAsync(long id);
    Task<bool> UpdateViajeAsync(Viaje viaje);
    Task<bool> Save();
    */
}
