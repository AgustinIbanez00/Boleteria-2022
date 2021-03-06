using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;

namespace BoleteriaOnline.Core.ViewModels.Pagging;
public class PaginationFilter
{
    [GreaterThanZero, Display(Name = "página")]
    public int Pagina { get; set; } = 1;

    private int recordsPorPagina = 10;
    private readonly int cantidadMaximaRecordsPorPagina = 50;

    public bool Paginar { get; set; }

    [GreaterThanZero, Display(Name = "elementos por página"), Range(1, 100)]
    public int RecordsPorPagina
    {
        get
        {
            return recordsPorPagina;
        }
        set
        {
            recordsPorPagina = (value > cantidadMaximaRecordsPorPagina) ? cantidadMaximaRecordsPorPagina : value;
        }
    }
}
