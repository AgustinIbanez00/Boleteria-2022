using System.Linq.Expressions;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Repository;

public class ParadaRepository : IParadaRepository
{
    private readonly ApplicationDbContext _context;

    public ParadaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Parada entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.Id = 0;
        entity.Estado = Estado.Activo;
        await _context.Paradas.AddAsync(entity);
        return await Save();
    }

    public async Task<bool> DeleteAsync(Parada entity)
    {
        if (entity == null)
            return false;

        _context.Paradas.Remove(entity);

        return await Save();
    }
    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Parada entity)
    {
        if (entity == null)
            return false;

        _context.Paradas.Update(entity);
        entity.UpdatedAt = DateTime.Now;
        return await Save();
    }

    public Task<bool> ExistsAsync(ParadaFilter filter)
    {
        return _context.Paradas.AnyAsync(GetExpression(filter));
    }

    public async Task<bool> DeleteAsync(ParadaFilter filter)
    {
        var parada = await GetAsync(filter);
        return await DeleteAsync(parada);
    }

    public Expression<Func<Parada, bool>> GetExpression(ParadaFilter filter)
    {
        return PredicateBuilder.New<Parada>()
            .And(p => !filter.Id.HasValue || filter.Id.HasValue && p.Id == filter.Id.Value)
            .And(p => string.IsNullOrEmpty(filter.Nombre) || !string.IsNullOrEmpty(filter.Nombre) && p.Nombre.Contains(filter.Nombre))
            .And(p => !filter.Estado.HasValue || filter.Estado.HasValue && p.Estado == filter.Estado.Value);
    }

    public async Task<ICollection<Parada>> GetAllAsync(ParadaFilter filter)
    {
        return await _context.Paradas.Include(p => p.Pais).Include(p => p.Provincia).Where(GetExpression(filter)).ToListAsync();
    }

    public async Task<Parada> GetAsync(ParadaFilter filter)
    {
        return await _context.Paradas.FirstOrDefaultAsync(GetExpression(filter));
    }

    public async Task<PaginatedList<Parada>> GetAllPaginatedAsync(ParadaFilter filter)
    {
        return await PaggingExtensions.CreateAsync(_context.Paradas.Include(p => p.Pais).Include(p => p.Provincia).Where(GetExpression(filter)), filter.Pagina, filter.RecordsPorPagina);
    }

    public async Task<Parada> FindAsync(int id)
    {
        return await _context.Paradas.FindAsync(id);
    }
}
