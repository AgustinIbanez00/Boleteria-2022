using BoleteriaOnline.Core.Utils;
namespace BoleteriaOnline.Core.Services;
public interface IGenericService<TResponse, TFilter> where TResponse : class
{
    Task<WebResultList<TResponse>> AllAsync(TFilter parameters);
    Task<WebResult<TResponse>> GetAsync(long id);
    Task<WebResult<TResponse>> CreateAsync(TResponse request);
    Task<WebResult<TResponse>> UpdateAsync(TResponse request, long id);
    Task<WebResult<TResponse>> DeleteAsync(long id);
}
