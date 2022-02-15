using Humanizer;

namespace BoleteriaOnline.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class HumanDescriptionAttribute : Attribute
    {
        public HumanDescriptionAttribute(string name, GrammaticalGender gender)
        {
            Name = name;
            Gender = gender;
        }

        public string Name { get; set; }
        public GrammaticalGender Gender { get; set; }
    }
}
