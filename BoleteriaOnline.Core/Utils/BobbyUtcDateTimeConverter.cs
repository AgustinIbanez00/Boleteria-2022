using System.Text.Json;
using System.Text.Json.Serialization;

namespace BoleteriaOnline.Core.Utils;
public class BobbyUtcDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (JsonDocument jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            return DateTime.SpecifyKind(
                DateTime.Parse(jsonDoc.RootElement.GetRawText().Trim('"').Trim('\'')),
                DateTimeKind.Utc
            );
        }
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-ddTHH:mm:ss.fffZ", System.Globalization.CultureInfo.InvariantCulture));
    }
}
