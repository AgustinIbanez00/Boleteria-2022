using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Web.Repositories;
public interface IGenericRepository<TKey, TEntity, TFilter> where TEntity : class
{
    Task<ICollection<TEntity>> GetAllAsync(TFilter filter);
    Task<PaginatedList<TEntity>> GetAllPaginatedAsync(TFilter filter);
    Task<TEntity> GetAsync(TFilter filter);
    Task<TEntity> FindAsync(TKey id);
    Task<bool> ExistsAsync(TFilter filter);
    Task<bool> CreateAsync(TEntity entity);
    Task<bool> DeleteAsync(TEntity entity);
    Task<bool> DeleteAsync(TFilter filter);
    Task<bool> UpdateAsync(TEntity entity);
    Expression<Func<TEntity, bool>> GetExpression(TFilter filter);
    Task<bool> Save();
}
