using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("cliente", GrammaticalGender.Masculine)]
public class ClienteDTO
{
    [Required, Display(Name = "número de documento")]
    public long Dni { get; set; }

    [Required, Display(Name = "nombre")]
    public string Nombre { get; set; }

    [Required, Display(Name = "fecha de nacimiento"), DataType(DataType.DateTime)]
    public DateTime FechaNacimiento { get; set; }

    [Required, Display(Name = "género")]
    public Gender Genero { get; set; }

    [Display(Name = "estado")]
    public Estado Estado { get; set; } = Estado.Activo;
}
