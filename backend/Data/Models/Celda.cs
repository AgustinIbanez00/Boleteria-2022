using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Web.Data.Models;
public class Celda : AuditoryDates
{
    public int Id { get; set; }

    public int FilaId { get; set; }
    public DistribucionEspacio Value { get; set; } = DistribucionEspacio.ESPACIO_NULL;
}
