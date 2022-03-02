using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("parada", GrammaticalGender.Feminine)]
public class ParadaDTO
{
    public int Id { get; set; }
    [Required, Display(Name = "nombre"), MinLength(3), MaxLength(100)]
    public string Nombre { get; set; }
    [Required, Display(Name = "país"), GreaterThanZero]
    public int PaisId { get; set; }
    [Required, Display(Name = "provincia"), GreaterThanZero]
    public int ProvinciaId { get; set; }
    [Required, Display(Name = "estado"), GreaterThanZero]
    public Estado Estado { get; set; }
}
