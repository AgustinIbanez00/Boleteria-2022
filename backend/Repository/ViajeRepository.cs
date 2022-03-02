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

public class ViajeRepository : IViajeRepository
{
    private readonly ApplicationDbContext _context;

    public ViajeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Viaje entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.Id = 0;
        entity.Estado = Estado.Activo;
        await _context.Viajes.AddAsync(entity);
        return await Save();
    }

    public async Task<bool> DeleteAsync(Viaje entity)
    {
        if (entity == null)
            return false;

        _context.Viajes.Remove(entity);

        return await Save();
    }

    public async Task<bool> DeleteAsync(ViajeFilter filter)
    {
        Viaje viaje = await GetAsync(filter);
        return await DeleteAsync(viaje);
    }

    public Task<bool> ExistsAsync(ViajeFilter filter)
    {
        return _context.Viajes.AnyAsync(GetExpression(filter));
    }

    public async Task<Viaje> FindAsync(int id)
    {
        return await _context.Viajes.Include(v => v.Horarios.OrderBy(h=> h.Hora))
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task<ICollection<Viaje>> GetAllAsync(ViajeFilter filter)
    {
        return await _context.Viajes.Where(GetExpression(filter)).ToListAsync();
    }

    public async Task<PaginatedList<Viaje>> GetAllPaginatedAsync(ViajeFilter filter)
    {
        return await PaggingExtensions.CreateAsync(_context.Viajes.Where(GetExpression(filter)), filter.Pagina, filter.RecordsPorPagina);
    }

    public async Task<Viaje> GetAsync(ViajeFilter filter)
    {
        return await _context.Viajes.Include(v => v.Horarios.OrderBy(h => h.Hora)).FirstOrDefaultAsync(GetExpression(filter));
    }

    public Expression<Func<Viaje, bool>> GetExpression(ViajeFilter filter)
    {
        return PredicateBuilder.New<Viaje>()
            .And(p => !filter.Id.HasValue || filter.Id.HasValue && p.Id == filter.Id.Value)
            .And(p => string.IsNullOrEmpty(filter.Nombre) || !string.IsNullOrEmpty(filter.Nombre) && p.Nombre.Contains(filter.Nombre))
            .And(p => !filter.Estado.HasValue || (filter.Estado.HasValue && p.Estado == filter.Estado.Value))
        ;
    }

    public async Task<Viaje> GetViajeAsync(long id) => await _context.Viajes.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<ICollection<Viaje>> GetViajesAsync() => await _context.Viajes.ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Viaje entity)
    {
        if (entity == null)
            return false;

        _context.Viajes.Update(entity);
        entity.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
