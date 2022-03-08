namespace BoleteriaOnline.Web.Data.Models;
public class Horario
{
    public int Id { get; set; }
    public DateTime Hora { get; set; }
    public int DistribucionId { get; set; }
    //public Distribucion Distribucion { get; set; }
    [MaxLength(7)]
    public string Dias { get; set; }
}
