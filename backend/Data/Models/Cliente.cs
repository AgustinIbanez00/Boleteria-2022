using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;
using Humanizer;

namespace BoleteriaOnline.Web.Data.Models;
[HumanDescription("cliente", GrammaticalGender.Masculine)]
public class Cliente : Auditory
{
    public long Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public DateTime FechaNac { get; set; }
    [Required]
    public string Nacionalidad { get; set; }
    public Gender? Genero { get; set; }
}
