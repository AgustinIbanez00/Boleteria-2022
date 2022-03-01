using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Services;
public class PaisRepository : IPaisRepository
{
    private readonly ApplicationDbContext _context;

    public PaisRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Pais>> GetAllAsync(PaisFilter parameters)
    {
        IQueryable<Pais> dbSet = null;

        dbSet = _context.Paises;

        if (parameters.Id.HasValue)
            dbSet = dbSet.Where(p => p.Id == parameters.Id.Value);
        if (!string.IsNullOrEmpty(parameters.Nombre))
            dbSet = dbSet.Where(p => p.Nombre.Contains(parameters.Nombre));

        return await PaggingExtensions.CreateAsync(dbSet, parameters.Pagina, parameters.RecordsPorPagina);
    }
}
