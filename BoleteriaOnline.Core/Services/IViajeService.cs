using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface IViajeService
{
    Task<WebResult<ICollection<ViajeResponse>>> GetViajesAsync();
    Task<WebResult<ViajeResponse>> GetViajeAsync(long id);
    Task<WebResult<ViajeResponse>> CreateViajeAsync(ViajeRequest viajeDto);
    Task<WebResult<ViajeResponse>> UpdateViajeAsync(ViajeUpdateRequest viajeDto);
    Task<WebResult<ViajeResponse>> DeleteViajeAsync(long id);
}
