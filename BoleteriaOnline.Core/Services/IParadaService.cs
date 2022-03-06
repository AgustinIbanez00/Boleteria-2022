using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IParadaService : IGenericService<int, ParadaDTO, ParadaFilter>
{
}
