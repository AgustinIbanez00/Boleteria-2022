using System.ComponentModel;

namespace BoleteriaOnline.Core.Extensions.Response;
public enum ErrorMessage
{
    [Description("Se produjo un error interno.")]
    Generic,
    [Description("No existe ninguna cuenta asociada con ese correo electrónico.")]
    InvalidEmail,
    [Description("La contraseña ingresada es incorrecta.")]
    InvalidPassword,
    [Description("El identificador es inválido.")]
    InvalidId,
    [Description("No se puede crear {Gender:un|una} {Entity} con el mismo identificador.")]
    DuplicatedEntity,
    [Description("No se encontró {Gender:ningún|ninguna} {Entity}.")]
    NotFound,
    [Description("Existe {Gender:un|una} {Entity} con esos datos.")]
    AlreadyExists,
    [Description("{Gender:El|La} {Entity} ya se encuentra {Gender:eliminado|eliminada}.")]
    AlreadyDeleted,
    [Description("No se pudo crear {Gender:ese|esa} {Entity}.")]
    CouldNotCreate,
    [Description("No se pudo eliminar {Gender:ese|esa} {Entity}.")]
    CouldNotDelete,
    [Description("No se pudo modificar {Gender:ese|esa} {Entity}.")]
    CouldNotUpdate,
    [Description("No se puede crear {Gender:un|una} {Entity} {Gender:vacío|vacía}.")]
    EmptyList,
    [Description("Ocurrieron uno o más errores durante la validación.")]
    GenericValidation,
    [Description("No se pudo eliminar {Gender:ese|esa} {Entity} porque se está utilizando en otro lugar.")]
    CouldNotDeleteReferenced
}
