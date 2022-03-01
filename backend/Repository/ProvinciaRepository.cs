using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class ProvinciaRepository : IProvinciaRepository
{
    private readonly ApplicationDbContext _context;

    public ProvinciaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<Provincia>> GetAllAsync(ProvinciaFilter parameters)
    {
        IQueryable<Provincia> dbSet = null;

        dbSet = _context.Provincias;

        if (parameters.Id.HasValue)
            dbSet = dbSet.Where(p => p.Id == parameters.Id.Value);
        if (!string.IsNullOrEmpty(parameters.Nombre))
            dbSet = dbSet.Where(p => p.Nombre.Contains(parameters.Nombre));
        if (parameters.PaisId.HasValue)
            dbSet = dbSet.Where(p => p.PaisId == parameters.PaisId.Value);

        return await PaggingExtensions.CreateAsync(dbSet, parameters.Pagina, parameters.RecordsPorPagina);
    }
}
