using BoleteriaOnline.Core.Attributes;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
[Index(nameof(Nombre), IsUnique = true)]
[HumanDescription("parada", GrammaticalGender.Masculine)]
public class Parada : AuditoryDates
{
    public int Id { get; set; }
    [StringLength(100)]
    public string Nombre { get; set; }

    public string Provincia { get; set; }

    public Pais Pais { get; set; }
}
