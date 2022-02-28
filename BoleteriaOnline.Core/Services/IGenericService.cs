using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.Services;

public interface IGenericService<T> where T : class
{
    Task<WebResult<PaginatedList<T>>> AllAsync(Pagination parameters);
    Task<WebResult<T>> GetAsync(long id);
    Task<WebResult<T>> CreateAsync(T request);
    Task<WebResult<T>> UpdateAsync(T request, long id);
    Task<WebResult<T>> DeleteAsync(long id);
}
