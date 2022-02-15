using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Requests;
using BoleteriaOnline.Core.ViewModels.Responses;

namespace BoleteriaOnline.Core.Services;
public interface INodoService
{
    Task<WebResult<ICollection<NodoResponse>>> GetNodosAsync();
    Task<WebResult<NodoResponse>> GetNodoAsync(long id);
    Task<WebResult<NodoResponse>> CreateNodoAsync(NodoRequest nodoDto);
    Task<WebResult<NodoResponse>> UpdateNodoAsync(NodoRequest nodoDto);
    Task<WebResult<NodoResponse>> DeleteNodoAsync(long id);
}
