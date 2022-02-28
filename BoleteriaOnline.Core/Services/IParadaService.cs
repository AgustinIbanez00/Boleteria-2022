using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.Services;
public interface IParadaService
{
    Task<WebResult<PaginatedList<ParadaDTO>>> GetParadasAsync(Pagination parameters);
    Task<WebResult<ParadaDTO>> GetParadaAsync(long id);
    Task<WebResult<ParadaDTO>> CreateParadaAsync(ParadaDTO request);
    Task<WebResult<ParadaDTO>> UpdateParadaAsync(ParadaDTO request, long id);
    Task<WebResult<ParadaDTO>> DeleteParadaAsync(long id);
}
