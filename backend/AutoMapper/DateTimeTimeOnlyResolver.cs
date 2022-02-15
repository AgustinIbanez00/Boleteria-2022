using AutoMapper;

namespace BoleteriaOnline.Web.AutoMapper;
public class DateTimeTimeOnlyResolver : IMemberValueResolver<object, object, DateTime, TimeOnly>
{
    public TimeOnly Resolve(object s, object d, DateTime source, TimeOnly dest, ResolutionContext context)
    {
        return TimeOnly.FromDateTime(source);
    }

}
