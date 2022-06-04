using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Web.Data.Models;

public class Usuario
{
    public long Id { get; set; }
    public string Email { get; set; }
    [MaxLength(25)]
    public string UserName { get; set; }
    [MaxLength(150)]
    public string Password { get; set; }
    public bool IsBan { get; set; }
    public string Salt { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public Gender Gender { get; set; } = Gender.NOTDEFINED;
    public UsuarioTipo Tipo { get; set; } = UsuarioTipo.NORMAL_USER;
}
