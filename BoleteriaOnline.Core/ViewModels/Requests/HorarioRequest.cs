using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class HorarioRequest
{
    [Required, Display(Name = "hora")]
    public DateTime Hora { get; set; }
    
    [Required, Display(Name = "días de la semana")]
    public IEnumerable<DayOfWeek> Dias { get; set; }

    [Required]
    public int DistribucionId { get; set; }
}
