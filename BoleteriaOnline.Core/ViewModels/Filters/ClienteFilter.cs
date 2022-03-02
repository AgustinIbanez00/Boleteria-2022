using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Web.Data.Filters;
public class ClienteFilter : PaginationFilter
{
    public long? Dni { get; set; }

    public string Nombre { get; set; }

    public DateTime? FechaNacimiento { get; set; }
    public int? NacionalidadId { get; set; }
    public Gender? Genero { get; set; }

    public Estado? Estado { get; set; }

}
