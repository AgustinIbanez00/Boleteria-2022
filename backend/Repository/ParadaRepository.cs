using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class ParadaRepository : IParadaRepository
{
    private readonly ApplicationDbContext _context;

    public ParadaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Parada destino)
    {
        destino.CreatedAt = DateTime.Now;
        destino.Id = 0;
        await _context.Paradas.AddAsync(destino);
        return await Save();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        Parada destino = await GetAsync(id);
        return destino == null ? false : await DeleteAsync(destino);
    }

    public async Task<bool> DeleteAsync(Parada destino)
    {
        if (destino == null)
            return false;

        _context.Paradas.Remove(destino);

        return await Save();
    }

    public async Task<bool> ExistsAsync(long id) => await _context.Paradas.AnyAsync(e => e.Id == id);

    public async Task<Parada> GetAsync(long id) => await _context.Paradas.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<ICollection<Parada>> GetAllAsync() => await _context.Paradas.ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Parada destino)
    {
        if (destino == null)
            return false;

        _context.Paradas.Update(destino);
        destino.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
