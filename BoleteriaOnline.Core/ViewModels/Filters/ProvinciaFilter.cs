using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.ViewModels.Filters;
public class ProvinciaFilter : PaginationFilter
{
    public int? Id { get; set; }
    public string Nombre { get; set; }

    public int? PaisId { get; set; }
}
