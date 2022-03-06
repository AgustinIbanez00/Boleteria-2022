using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IViajeService : IGenericService<int, ViajeDTO, ViajeFilter>
{
}
