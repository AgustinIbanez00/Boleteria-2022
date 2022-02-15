using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class FilaRequest
{
    [Required, Display(Name = "celdas")]
    public List<CeldaRequest> Cells { get; set; }

    [Required, Display(Name = "planta")]
    public Planta Planta { get; set; }

}
