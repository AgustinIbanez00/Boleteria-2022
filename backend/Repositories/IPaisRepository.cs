using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IPaisRepository
{
    Task<ICollection<Pais>> GetAllAsync(PaisFilter parameters);

    Task<Pais> GetAsync(PaisFilter parameters);

    Task<bool> ExistsAsync(PaisFilter parameters);

    Expression<Func<Pais, bool>> GetExpression(PaisFilter parameters);

}
