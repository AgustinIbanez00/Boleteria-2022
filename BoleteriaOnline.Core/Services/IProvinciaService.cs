using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;

public interface IProvinciaService
{
    public Task<WebResultList<ProvinciaDTO>> AllAsync(ProvinciaFilter parameters);
}
