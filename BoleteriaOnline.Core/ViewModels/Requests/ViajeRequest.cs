using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class ViajeRequest
{
    [Required, Display(Name = "nombre")]
    public string Nombre { get; set; }

    [Required, Display(Name = "horario")]
    public List<HorarioRequest> Horarios { get; set; }

    //[Required, Display(Name = "conexiones")]
    //public List<NodoRequest> Nodos { get; set; }
}