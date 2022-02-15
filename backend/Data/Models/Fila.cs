using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Web.Data.Models;
public class Fila
{
    [Key]
    public int Id { get; set; }
    public List<Celda> Cells { get; set; }

    public int DistribucionId { get; set; }

    public Planta Planta { get; set; }
}
