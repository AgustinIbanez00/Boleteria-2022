using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.ViewModels.Requests;

namespace BoleteriaOnline.Core.ViewModels;
public class ParadaDTO
{
    public int Id { get; set; }

    [Required, Display(Name = "nombre"), StringLength(100)]
    public string Nombre { get; set; }

    public Estado Estado { get; set; }
}
