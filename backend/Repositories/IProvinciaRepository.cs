using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IProvinciaRepository
{
    Task<PaginatedList<Provincia>> GetAllAsync(ProvinciaFilter parameters);

}
