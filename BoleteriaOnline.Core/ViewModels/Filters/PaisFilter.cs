using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.ViewModels.Filters;
public class PaisFilter : PaginationFilter
{
    public int? Id { get; set; }
    public string Nombre { get; set; }
}
