using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IClienteService : IGenericService<long, ClienteDTO, ClienteFilter>
{

}
