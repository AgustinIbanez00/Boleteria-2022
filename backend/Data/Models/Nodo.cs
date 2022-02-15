using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoleteriaOnline.Web.Data.Models;

public class Nodo : AuditoryDates
{
    [Key]
    public int Id { get; set; }
    public Destino Origen { get; set; }
    public Destino Destino { get; set; }
    [MaxLength(5)]
    public string Demora { get; set; }
    public float Precio { get; set; }
}
