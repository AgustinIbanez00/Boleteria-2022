using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class NodoRepository : INodoRepository
{
    private readonly ApplicationDbContext _context;

    public NodoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateNodoAsync(Nodo nodo)
    {
        nodo.CreatedAt = DateTime.Now;
        nodo.Id = 0;
        await _context.Nodos.AddAsync(nodo);
        return await Save();
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

    public async Task<bool> ExistsNodoAsync(long id) => await _context.Nodos.AnyAsync(e => e.Id == id);

    public async Task<Nodo> GetNodoAsync(long id) => await _context.Nodos.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<ICollection<Nodo>> GetNodosAsync() => await _context.Nodos.ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateNodoAsync(Nodo nodo)
    {
        if (nodo == null)
            return false;

        _context.Nodos.Update(nodo);
        nodo.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
