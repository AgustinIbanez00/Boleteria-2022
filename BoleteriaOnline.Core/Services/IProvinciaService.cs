using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;

namespace BoleteriaOnline.Core.Services;

public interface IProvinciaService
{
    Task<WebResult<List<ProvinciaDTO>>> AllAsync(ProvinciaFilter parameters);
}
