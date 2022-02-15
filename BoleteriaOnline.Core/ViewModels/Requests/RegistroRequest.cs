using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class RegistroRequest
{

    [Required, Display(Name = "correo electrónico"), EmailAddress]
    public string Email { get; set; }

    [Required, Display(Name = "contraseña"), DataType(DataType.Password), StringLength(255, MinimumLength = 6)]
    public string Password { get; set; }

    [Required, Display(Name = "confirmar contraseña"), DataType(DataType.Password), StringLength(255, MinimumLength = 6), Compare("Password")]
    public string ConfirmPassword { get; set; }

    [Required, Display(Name = "nombre"), StringLength(100)]
    public string FirstName { get; set; }

    [Required, Display(Name = "apellido"), StringLength(100)]
    public string LastName { get; set; }

    [Required, Display(Name = "dni"), GreaterThanZero]
    public long Dni { get; set; }

    [Required, Display(Name = "fecha de nacimiento"), DataType(DataType.Date)]
    public DateTime FechaNacimiento { get; set; }
}
