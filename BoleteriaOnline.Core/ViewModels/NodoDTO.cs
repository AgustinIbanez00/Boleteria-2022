using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;

namespace BoleteriaOnline.Core.ViewModels;
public class NodoDTO
{
    [Display(Name = "identificador")]
    public int Id { get; set; }

    [Required, Display(Name = "origen"), GreaterThanZero]
    public int OrigenId { get; set; }

    [Required, Display(Name = "destino"), GreaterThanZero]
    public int DestinoId { get; set; }

    [Required, Display(Name = "demora"), DataType(DataType.DateTime), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
    public string Demora { get; set; }

    [Required, Display(Name = "precio"), GreaterThanZero]
    public float Precio { get; set; }

    [Required, Display(Name = "viaje"), GreaterThanZero]
    public int ViajeId { get; set; }

}
