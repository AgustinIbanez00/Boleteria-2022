using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Core.Data.Enums;
public enum Estado
{
    /// <summary>
    /// Cuando una entidad se encuentra en este estado no se podrá listar, modificar ni eliminar.
    /// </summary>
    [Display(Name = "Baja")]
    Baja = 0,
    /// <summary>
    /// El objeto se encuentra en su estado default.
    /// </summary>
    [Display(Name = "Activo")]
    Activo = 1,
    /// <summary>
    /// Características similares al estado de BAJA.
    /// </summary>
    [Display(Name = "Suspendido")]
    Suspendido = -1,
}
