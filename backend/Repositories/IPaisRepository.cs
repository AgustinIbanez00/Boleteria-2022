using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IPaisRepository
{
    Task<PaginatedList<Pais>> GetAllAsync(PaisFilter parameters);

    Task<PaginatedList<Pais>> GetAsync(int id);

}
