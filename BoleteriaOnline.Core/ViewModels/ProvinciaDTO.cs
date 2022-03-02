using BoleteriaOnline.Core.Attributes;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("provincia", GrammaticalGender.Feminine)]
public class ProvinciaDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int PaisId { get; set; }
}
