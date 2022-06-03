using BoleteriaOnline.Core.ViewModels.Pagging;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Extensions;
public static class PaggingExtensions
{
    public static async Task<PaginatedList<T>> CreateAsync<T>(IQueryable<T> source, int pageIndex, int pageSize)
    {
        int count = await source.CountAsync();
        List<T> items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }

    public static PaginatedList<T> Create<T>(IQueryable<T> source, int pageIndex, int pageSize)
    {
        int count = source.Count();
        List<T> items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }


}
