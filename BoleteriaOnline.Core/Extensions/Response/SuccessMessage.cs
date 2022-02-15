using System.ComponentModel;

namespace BoleteriaOnline.Core.Extensions.Response;
public enum SuccessMessage
{
    [Description("{Gender:El|La} {Entity} se creó correctamente.")]
    Created,
    [Description("{Gender:El|La} {Entity} se eliminó correctamente.")]
    Deleted,
    [Description("{Gender:El|La} {Entity} se actualizó correctamente.")]
    Modified,
    [Description("No se encontraron datos.")]
    NoDataFound
}
