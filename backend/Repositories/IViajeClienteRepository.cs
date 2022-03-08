using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IViajeClienteRepository
{
    Task<ICollection<ViajeClienteDTO>> GetAllAsync(ViajeClienteFilter filter);
}
