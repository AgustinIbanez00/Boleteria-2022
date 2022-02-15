using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface IDestinoService
{
    Task<WebResult<ICollection<DestinoResponse>>> GetDestinosAsync();
    Task<WebResult<DestinoResponse>> GetDestinoAsync(long id);
    Task<WebResult<DestinoResponse>> CreateDestinoAsync(DestinoRequest destinoDto);
    Task<WebResult<DestinoResponse>> UpdateDestinoAsync(DestinoRequest destinoDto, long id);
    Task<WebResult<DestinoResponse>> DeleteDestinoAsync(long id);
}
