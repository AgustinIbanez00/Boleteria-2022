using System.ComponentModel.DataAnnotations;

namespace BoleteriaOnline.Core.ViewModels.Requests;
public class ViajeUpdateRequest : ViajeRequest
{
    [Required, Display(Name = "id")]
    public int Id { get; set; }
}
