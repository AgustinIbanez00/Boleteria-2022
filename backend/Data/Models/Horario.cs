using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Web.Data.Models;
public class Horario
{
    public int Id { get; set; }
    public DateTime Hora { get; set; }
    public int DistribucionId { get; set; }
    //public Distribucion Distribucion { get; set; }
    public bool Lunes { get; set; }
    public bool Martes { get; set; }
    public bool Miercoles { get; set; }
    public bool Jueves { get; set; }
    public bool Viernes { get; set; }
    public bool Sabado { get; set; }
    public bool Domingo { get; set; }
}
