using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class DistribucionRequest
{
    [Required, Display(Name = "Filas")]
    public List<FilaRequest> Filas { get; set; }

    [Required, Display(Name = "nota"), MaxLength(128)]
    public string Nota { get; set; }

    [Required, Display(Name = "un piso")]
    public bool UnPiso { get; set; }

}
