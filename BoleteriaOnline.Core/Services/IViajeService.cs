using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IViajeService : IGenericService<int, ViajeDTO, ViajeFilter>
{
    /*
    Task<WebResult<ICollection<ViajeDTO>>> GetViajesAsync();
    Task<WebResult<ViajeDTO>> GetViajeAsync(long id);
    Task<WebResult<ViajeDTO>> CreateViajeAsync(ViajeDTO viajeDto);
    Task<WebResult<ViajeDTO>> UpdateViajeAsync(ViajeUpdateRequest viajeDto);
    Task<WebResult<ViajeDTO>> DeleteViajeAsync(long id);
    */
}
