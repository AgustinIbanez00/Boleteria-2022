using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Repository;
public class PaisRepository : IPaisRepository
{
    private readonly ApplicationDbContext _context;

    public PaisRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> ExistsAsync(PaisFilter parameters)
    {
        return _context.Paises.AnyAsync(GetExpression(parameters));
    }

    public Expression<Func<Pais, bool>> GetExpression(PaisFilter parameters)
    {
        return PredicateBuilder.New<Pais>()
            .And(p => !parameters.Id.HasValue || parameters.Id.HasValue && p.Id == parameters.Id.Value)
            .And(p => string.IsNullOrEmpty(parameters.Nombre) || !string.IsNullOrEmpty(parameters.Nombre) && p.Nombre.Contains(parameters.Nombre));
    }

    public async Task<ICollection<Pais>> GetAllAsync(PaisFilter parameters)
    {
        return await _context.Paises.Where(GetExpression(parameters)).ToListAsync();
    }

    public async Task<Pais> GetAsync(PaisFilter parameters)
    {
        return await _context.Paises.FirstOrDefaultAsync(GetExpression(parameters));
    }
}
