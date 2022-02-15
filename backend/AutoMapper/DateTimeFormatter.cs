using AutoMapper;

namespace BoleteriaOnline.Web.AutoMapper;
public class DateTimeFormatter : IValueConverter<TimeOnly, DateTime?>
{
    public DateTime? Convert(TimeOnly source, ResolutionContext context)
        => new DateTime(0, 0, 0, source.Hour, source.Minute, source.Second);
}
