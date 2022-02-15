using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Data.Enums;
using Microsoft.AspNetCore.Identity;

namespace BoleteriaOnline.Web.Data.Models;



public class Usuario : IdentityUser<long>
{
    [MaxLength(25)]
    public string Username { get; set; }
    [MaxLength(150)]
    public string Password { get; set; }
    public string Salt { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Gender Gender { get; set; } = Gender.NOTDEFINED;
    public UsuarioTipo Tipo { get; set; } = UsuarioTipo.NORMAL_USER;
}
