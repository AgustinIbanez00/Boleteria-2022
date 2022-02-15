using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
[Index(nameof(Nombre), IsUnique = true)]
public class Viaje : AuditoryDates
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Nombre { get; set; }
    public List<Horario> Horarios { get; set; }
    public List<Nodo> Nodos { get; set; }
}
