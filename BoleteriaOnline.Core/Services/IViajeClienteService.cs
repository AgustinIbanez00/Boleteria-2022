using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IViajeClienteService
{
    Task<WebResultList<ViajeClienteDTO>> AllAsync(ViajeClienteFilter filter);

}
