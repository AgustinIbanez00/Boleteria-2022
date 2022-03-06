using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.ViewModels.Filters;

public class NodoFilter : PaginationFilter
{
    public int? Id { get; set; }
    public int? OrigenId { get; set; }

    public int? DestinoId { get; set; }

    public string Demora { get; set; }

    public float? Precio { get; set; }

    public int? ViajeId { get; set; }
}
