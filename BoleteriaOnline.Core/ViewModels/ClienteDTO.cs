using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Core.ViewModels;
public class ClienteDTO
{
    [Required, Display(Name = "número de documento")]
    public long Dni { get; set; }

    [Required, Display(Name = "nombre")]
    public string Nombre { get; set; }

    [Required, Display(Name = "fecha de nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Required, Display(Name = "nacionalidad")]
    public int NacionalidadId { get; set; }

    [Required, Display(Name = "género")]
    public Gender Genero { get; set; }

    [Display(Name = "estado")]
    public Estado Estado { get; set; } = Estado.Activo;
}
