using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories;
public interface IParadaRepository : IGenericRepository<int, Parada, ParadaFilter>
{
}
