using System.ComponentModel.DataAnnotations;
using BoleteriaOnline.Core.Attributes;
using BoleteriaOnline.Core.Data.Enums;

namespace BoleteriaOnline.Core.ViewModels.Requests;

public class DistribucionUpdateRequest
{
    public long Id { get; set; }

    [Required, Display(Name = "Filas")]
    public List<FilaUpdateRequest> Filas { get; set; }

    [Required, Display(Name = "nota"), MaxLength(128)]
    public string Nota { get; set; }

    [Required, Display(Name = "un piso")]
    public bool UnPiso { get; set; }
}

public class FilaUpdateRequest
{
    [Required, Display(Name = "id"), GreaterThanZero]
    public int Id { get; set; }

    [Required, Display(Name = "celdas")]
    public List<CeldaUpdateRequest> Cells { get; set; }

    [Required, Display(Name = "planta")]
    public Planta Planta { get; set; }
}

public class CeldaUpdateRequest : CeldaRequest
{
    public int Id { get; set; }
}