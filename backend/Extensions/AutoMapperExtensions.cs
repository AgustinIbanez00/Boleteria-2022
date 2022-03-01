using AutoMapper;
using BoleteriaOnline.Core.ViewModels.Pagging;

namespace BoleteriaOnline.Web.Extensions;
public static class AutoMapperExtensions
{
    public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, List<TSource> source)
    {
        return mapper.Map<List<TDestination>>(source);
    }

    public static PaginatedList<TDestination> MapPaginatedList<TSource, TDestination>(this IMapper mapper, IQueryable<TSource> source, PaginationFilter pagination)
    {
        List<TDestination> result = new List<TDestination>();
        foreach (var item in source)
            result.Add(mapper.Map<TDestination>(item));
        
        return PaggingExtensions.Create(result.AsQueryable(), pagination.Pagina, pagination.RecordsPorPagina);
    }



}
