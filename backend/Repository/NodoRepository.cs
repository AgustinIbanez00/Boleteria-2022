using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Repository;

public class NodoRepository : INodoRepository
{
    private readonly ApplicationDbContext _context;

    public NodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Nodo entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.Id = 0;
        await _context.Nodos.AddAsync(entity);
        return await Save();
    }

    public async Task<bool> DeleteAsync(Nodo entity)
    {
        if (entity == null)
            return false;

        _context.Nodos.Remove(entity);

        return await Save();
    }

    public async Task<bool> DeleteAsync(NodoFilter filter)
    {
        Nodo cliente = await GetAsync(filter);
        return await DeleteAsync(cliente);
    }

    public async Task<bool> DeleteNodoAsync(long id)
    {
        Nodo nodo = await GetNodoAsync(id);
        return nodo == null ? false : await DeleteNodoAsync(nodo);
    }

    public async Task<bool> DeleteNodoAsync(Nodo nodo)
    {
        if (nodo == null)
            return false;

        _context.Nodos.Remove(nodo);
        return await Save();
    }

    public async Task<bool> ExistsAsync(NodoFilter filter)
    {
        return await _context.Nodos.AnyAsync(GetExpression(filter));
    }

    public async Task<Nodo> FindAsync(int id)
    {
        return await _context.Nodos.FindAsync(id);
    }

    public async Task<ICollection<Nodo>> GetAllAsync(NodoFilter filter)
    {
        return await _context.Nodos.Where(GetExpression(filter)).ToListAsync();
    }

    public async Task<PaginatedList<Nodo>> GetAllPaginatedAsync(NodoFilter filter)
    {
        return await PaggingExtensions.CreateAsync(_context.Nodos.Where(GetExpression(filter)), filter.Pagina, filter.RecordsPorPagina);
    }

    public async Task<Nodo> GetAsync(NodoFilter filter)
    {
        return await _context.Nodos.FirstOrDefaultAsync(GetExpression(filter));
    }

    public Expression<Func<Nodo, bool>> GetExpression(NodoFilter filter)
    {
        return PredicateBuilder.New<Nodo>()
            .And(p => !filter.Id.HasValue || (filter.Id.HasValue && p.Id == filter.Id.Value))
            .And(p => !filter.OrigenId.HasValue || (filter.OrigenId.HasValue && p.OrigenId == filter.OrigenId.Value))
            .And(p => !filter.DestinoId.HasValue || (filter.DestinoId.HasValue && p.DestinoId == filter.DestinoId.Value))
            .And(p => string.IsNullOrEmpty(filter.Demora) || (!string.IsNullOrEmpty(filter.Demora) && p.Demora.Contains(filter.Demora)))
            .And(p => !filter.Precio.HasValue || (filter.Precio.HasValue && p.Precio == filter.Precio.Value))
            .And(p => !filter.ViajeId.HasValue || (filter.ViajeId.HasValue && p.ViajeId == filter.ViajeId.Value))
            ;
    }

    public async Task<Nodo> GetNodoAsync(long id) => await _context.Nodos.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<ICollection<Nodo>> GetNodosAsync() => await _context.Nodos.ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Nodo entity)
    {
        if (entity == null)
            return false;

        _context.Nodos.Update(entity);
        entity.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
