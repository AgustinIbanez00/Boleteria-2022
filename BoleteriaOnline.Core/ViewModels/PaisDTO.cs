using BoleteriaOnline.Core.Attributes;
using Humanizer;

namespace BoleteriaOnline.Core.ViewModels;
[HumanDescription("país", GrammaticalGender.Feminine)]
public class PaisDTO
{
    public int Id { get; set; }
    public string Nombre { get; set; }
}
