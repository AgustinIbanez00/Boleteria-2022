using BoleteriaOnline.Core.Utils;
namespace BoleteriaOnline.Core.Services;
public interface IGenericService<TKey, TResponse, TFilter> where TResponse : class
{
    Task<WebResultList<TResponse>> AllAsync(TFilter filter);
    Task<WebResult<TResponse>> GetAsync(TFilter filter);
    Task<WebResult<TResponse>> CreateAsync(TResponse request);
    Task<WebResult<TResponse>> UpdateAsync(TResponse request, TKey id);
    Task<WebResult<TResponse>> DeleteAsync(TFilter filter);
    Task<WebResult<TResponse>> ValidateAsync(TResponse request);
}
