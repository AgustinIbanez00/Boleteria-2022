using System.ComponentModel.DataAnnotations;
namespace BoleteriaOnline.Web.Data.Models;
public class UserInfo
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}
