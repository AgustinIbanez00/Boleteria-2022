using BoleteriaOnline.Core.Attributes;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
[Index(nameof(Nombre), IsUnique = true)]
public class Parada : Auditory
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Nombre { get; set; }

    public string Provincia { get; set; }

    public Pais Pais { get; set; }
}
