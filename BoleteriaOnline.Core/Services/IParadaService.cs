using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;

namespace BoleteriaOnline.Core.Services;
public interface IParadaService
{
    Task<WebResult<ICollection<ParadaDTO>>> GetParadasAsync();
    Task<WebResult<ParadaDTO>> GetParadaAsync(long id);
    Task<WebResult<ParadaDTO>> CreateParadaAsync(ParadaDTO request);
    Task<WebResult<ParadaDTO>> UpdateParadaAsync(ParadaDTO request, long id);
    Task<WebResult<ParadaDTO>> DeleteParadaAsync(long id);
}
