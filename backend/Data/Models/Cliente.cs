using System.ComponentModel.DataAnnotations.Schema;
using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;
using Humanizer;

namespace BoleteriaOnline.Web.Data.Models;
[HumanDescription("cliente", GrammaticalGender.Masculine)]
public class Cliente : Auditory
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public long Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public DateTime FechaNac { get; set; }
    public Gender Genero { get; set; }
}
