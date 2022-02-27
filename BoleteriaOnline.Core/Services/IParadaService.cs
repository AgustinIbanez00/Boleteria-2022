using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface IParadaService
{
    Task<WebResult<ICollection<ParadaResponse>>> GetParadasAsync();
    Task<WebResult<ParadaResponse>> GetParadaAsync(long id);
    Task<WebResult<ParadaResponse>> CreateParadaAsync(ParadaRequest request);
    Task<WebResult<ParadaResponse>> UpdateParadaAsync(ParadaRequest request, long id);
    Task<WebResult<ParadaResponse>> DeleteParadaAsync(long id);
}
