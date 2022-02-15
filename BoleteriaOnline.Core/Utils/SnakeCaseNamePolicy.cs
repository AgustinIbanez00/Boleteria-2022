using System.Text.Json;
using BoleteriaOnline.Core.Extensions;

namespace BoleteriaOnline.Core.Utils;
public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return new string(name.ToSnakeCase().ToArray());
    }
}
