using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface INodoService : IGenericService<int, NodoDTO, NodoFilter>
{
}
