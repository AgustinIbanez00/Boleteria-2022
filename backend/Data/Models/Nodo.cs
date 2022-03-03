namespace BoleteriaOnline.Web.Data.Models;

public class Nodo : AuditoryDates
{
    [Key]
    public int Id { get; set; }
    public Parada Origen { get; set; }
    public int OrigenId { get; set; }
    public Parada Destino { get; set; }
    public int DestinoId { get; set; }
    [MaxLength(5)]
    public string Demora { get; set; }
    public float Precio { get; set; }
    public Viaje Viaje { get; set; }
    public int ViajeId { get; set; }

}
