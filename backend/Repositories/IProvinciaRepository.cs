using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IProvinciaRepository
{
    Task<ICollection<Provincia>> GetAllAsync(ProvinciaFilter parameters);

    Task<Provincia> GetAsync(ProvinciaFilter parameters);

    Task<bool> ExistsAsync(ProvinciaFilter parameters);

    Expression<Func<Provincia, bool>> GetExpression(ProvinciaFilter parameters);

}
