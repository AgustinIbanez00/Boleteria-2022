using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.ViewModels.Requests;

namespace BoleteriaOnline.Core.ViewModels.Responses;
public class ViajeResponse
{
    public int Id { get; set; }

    [Required, Display(Name = "nombre")]
    public string Nombre { get; set; }

    [Required, Display(Name = "horario")]
    public HorarioResponse[] Horarios { get; set; }


}
