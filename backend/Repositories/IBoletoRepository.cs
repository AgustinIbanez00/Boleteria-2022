using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Repositories
{
    public interface IBoletoRepository : IGenericRepository<int, Boleto, BoletoFilter>
    {
    }
}
