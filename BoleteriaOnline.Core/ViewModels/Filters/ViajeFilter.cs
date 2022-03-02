using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.ViewModels.Filters;
public class ViajeFilter : PaginationFilter
{
    public int? Id { get; set; }
    public string Nombre { get; set; }
    public Estado? Estado { get; set; }
}

