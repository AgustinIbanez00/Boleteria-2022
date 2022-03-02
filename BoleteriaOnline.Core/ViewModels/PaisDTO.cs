using BoleteriaOnline.Core.Attributes;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("país", GrammaticalGender.Masculine)]
public class PaisDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}
