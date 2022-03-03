using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Core.ViewModels.Filters;

public class ViajeClienteFilter : PaginationFilter
{
    [Required, Display(Name = "origen")]
    public int OrigenId { get; set; }
    [Required, Display(Name = "destino")]
    public int DestinoId { get; set; }
    [Required, Display(Name = "fecha"), DataType(DataType.Date)]
    public string Fecha { get; set; }

}
