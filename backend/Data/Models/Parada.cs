using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
[Index(nameof(Nombre), nameof(PaisId), nameof(ProvinciaId), IsUnique = true)]
public class Parada : Auditory
{
    public long Id { get; set; }
    [MaxLength(100)]
    public string Nombre { get; set; }
    public Pais Pais { get; set; }
    public Provincia Provincia { get; set; }
    public int PaisId { get; set; }
    public int ProvinciaId { get; set; }
}
