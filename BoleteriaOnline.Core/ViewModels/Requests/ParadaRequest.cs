using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class ParadaRequest
{
    [Required, Display(Name = "nombre"), StringLength(100)]
    public string Nombre { get; set; }

}
