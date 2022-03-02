using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("viaje", GrammaticalGender.Feminine)]
public class ViajeDTO
{
    public int Id { get; set; }

    [Required, Display(Name = "nombre")]
    public string Nombre { get; set; }

    [Required, Display(Name = "horario")]
    public List<HorarioDTO> Horarios { get; set; }

    [Display(Name = "estado")]
    public Estado Estado { get; set; }
}