using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Repository;

public class ProvinciaRepository : IProvinciaRepository
{
    private readonly ApplicationDbContext _context;

    public ProvinciaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> ExistsAsync(ProvinciaFilter parameters)
    {
        return _context.Provincias.AnyAsync(GetExpression(parameters));
    }

    public async Task<ICollection<Provincia>> GetAllAsync(ProvinciaFilter parameters)
    {
        return await _context.Provincias.Where(GetExpression(parameters)).ToListAsync();
    }

    public async Task<Provincia> GetAsync(ProvinciaFilter parameters)
    {
        return await _context.Provincias.FirstOrDefaultAsync(GetExpression(parameters));
    }

    public Expression<Func<Provincia, bool>> GetExpression(ProvinciaFilter filter)
    {
        return PredicateBuilder.New<Provincia>()
            .And(p => !filter.Id.HasValue || (filter.Id.HasValue && p.Id == filter.Id.Value))
            .And(p => string.IsNullOrEmpty(filter.Nombre) || (!string.IsNullOrEmpty(filter.Nombre) && p.Nombre.Contains(filter.Nombre)))
            .And(p => !filter.PaisId.HasValue || (filter.PaisId.HasValue && p.PaisId == filter.PaisId.Value));

    }
}
