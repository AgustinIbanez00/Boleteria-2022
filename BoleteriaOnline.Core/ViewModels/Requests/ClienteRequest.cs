using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Core.ViewModels.Requests;

public class ClienteRequest
{
    [Required, Display(Name = "número de documento")]
    public long Dni { get; set; }

    [Required, Display(Name = "nombre")]
    public string Nombre { get; set; }

    [Required, Display(Name = "fecha de nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Required, Display(Name = "nacionalidad")]
    public string Nacionalidad { get; set; }

    [Required, Display(Name = "género")]
    public Gender Genero { get; set; }
}
