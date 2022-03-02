using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
public class Viaje : Auditory
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Nombre { get; set; }
    public List<Horario> Horarios { get; set; }
    public List<Nodo> Nodos { get; set; }
}
