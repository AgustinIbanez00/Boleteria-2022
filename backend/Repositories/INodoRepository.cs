using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface INodoRepository : IGenericRepository<int, Nodo, NodoFilter>
{
    /*
    Task<ICollection<Nodo>> GetNodosAsync();
    Task<Nodo> GetNodoAsync(long id);
    Task<bool> ExistsNodoAsync(long id);
    Task<bool> CreateNodoAsync(Nodo nodo);
    Task<bool> DeleteNodoAsync(Nodo nodo);
    Task<bool> DeleteNodoAsync(long id);
    Task<bool> UpdateNodoAsync(Nodo nodo);
    Task<bool> Save();
    */
}
