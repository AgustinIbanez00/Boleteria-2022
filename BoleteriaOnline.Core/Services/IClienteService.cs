using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Web.Data.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IClienteService : IGenericService<long, ClienteDTO, ClienteFilter>
{

}
