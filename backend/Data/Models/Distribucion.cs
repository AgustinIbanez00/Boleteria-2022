using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Models;
[Index(nameof(Nota), IsUnique = true)]
[HumanDescription("distribución", Humanizer.GrammaticalGender.Feminine)]
public class Distribucion : AuditoryDates
{
    public int Id { get; set; }
    public List<Fila> Filas { get; set; }

    [StringLength(128)]
    public string Nota { get; set; }
    public bool UnPiso { get; set; }

    public Distribucion()
    {

    }

    public Distribucion(int cantidad_PB)
    {
        if (cantidad_PB / 5 > 0)
            this.InicializarListaCeldas(Planta.BAJA, cantidad_PB / 5, 5);
    }

    public Distribucion(int cantidad_PB, int cantidad_PA)
    {
        if (cantidad_PB / 5 > 0)
            this.InicializarListaCeldas(Planta.BAJA, cantidad_PB / 5, 5);
        if (cantidad_PA / 5 > 0)
            this.InicializarListaCeldas(Planta.ALTA, cantidad_PA / 5, 5);
    }
}
