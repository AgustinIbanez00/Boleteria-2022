using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("horario", GrammaticalGender.Feminine)]
public class HorarioDTO
{
    public int Id { get; set; }

    [Required, Display(Name = "hora"), DisplayFormat(DataFormatString = "HH:mm:ss")]
    public string Hora { get; set; }

    [Required, Display(Name = "días de la semana")]
    public IEnumerable<DayOfWeek> Dias { get; set; }

    [Required]
    public int DistribucionId { get; set; }
}
