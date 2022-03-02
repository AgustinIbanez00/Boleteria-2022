using AutoMapper;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.AutoMapper
{
    public class HorarioReverseResolver : IValueResolver<HorarioDTO, Horario, object>
    {
        public object Resolve(HorarioDTO source, Horario destination, object destMember, ResolutionContext context)
        {
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            if (source == null)
                throw new ArgumentNullException(nameof(destination));

            destination.Lunes = source.Dias.Contains(DayOfWeek.Monday);
            destination.Martes = source.Dias.Contains(DayOfWeek.Tuesday);
            destination.Miercoles = source.Dias.Contains(DayOfWeek.Wednesday);
            destination.Jueves = source.Dias.Contains(DayOfWeek.Thursday);
            destination.Viernes = source.Dias.Contains(DayOfWeek.Friday);
            destination.Sabado = source.Dias.Contains(DayOfWeek.Saturday);
            destination.Domingo = source.Dias.Contains(DayOfWeek.Sunday);

            return destination;
        }
    }
}
