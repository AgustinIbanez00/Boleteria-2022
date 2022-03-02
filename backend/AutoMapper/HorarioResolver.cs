using AutoMapper;
using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.AutoMapper
{
    public class HorarioResolver : IValueResolver<Horario, HorarioDTO, IEnumerable<DayOfWeek>>
    {
        public IEnumerable<DayOfWeek> Resolve(Horario source, HorarioDTO destination, IEnumerable<DayOfWeek> destMember, ResolutionContext context)
        {
            if (destination == null)
                throw new ArgumentNullException(nameof(destination));

            if (source == null)
                throw new ArgumentNullException(nameof(destination));

            List<DayOfWeek> dias = new List<DayOfWeek>();

            if (source.Lunes)
                dias.Add(DayOfWeek.Monday);

            if (source.Martes)
                dias.Add(DayOfWeek.Tuesday);

            if (source.Miercoles)
                dias.Add(DayOfWeek.Wednesday);

            if (source.Jueves)
                dias.Add(DayOfWeek.Thursday);

            if (source.Viernes)
                dias.Add(DayOfWeek.Friday);

            if (source.Sabado)
                dias.Add(DayOfWeek.Saturday);

            if (source.Domingo)
                dias.Add(DayOfWeek.Sunday);

            destination.Dias = dias;

            return dias;
        }
    }
}
