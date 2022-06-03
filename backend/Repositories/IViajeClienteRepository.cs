using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Web.Repositories;
public interface IViajeClienteRepository
{
    Task<ICollection<ViajeClienteDTO>> GetAllAsync(ViajeClienteFilter filter);
}
