using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;
public interface IPaisService
{
    Task<WebResultList<PaisDTO>> AllAsync(PaisFilter parameters);
}
