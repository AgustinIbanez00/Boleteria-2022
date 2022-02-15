using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class DestinoRepository : IDestinoRepository
{
    private readonly ApplicationDbContext _context;

    public DestinoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateDestinoAsync(Destino destino)
    {
        destino.CreatedAt = DateTime.Now;
        destino.Id = 0;
        await _context.Destinos.AddAsync(destino);
        return await Save();
    }

    public async Task<bool> DeleteDestinoAsync(long id)
    {
        Destino destino = await GetDestinoAsync(id);
        return destino == null ? false : await DeleteDestinoAsync(destino);
    }

    public async Task<bool> DeleteDestinoAsync(Destino destino)
    {
        if (destino == null)
            return false;

        _context.Destinos.Remove(destino);

        return await Save();
    }

    public async Task<bool> ExistsDestinoAsync(long id) => await _context.Destinos.AnyAsync(e => e.Id == id);

    public async Task<Destino> GetDestinoAsync(long id) => await _context.Destinos.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<ICollection<Destino>> GetDestinosAsync() => await _context.Destinos.ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateDestinoAsync(Destino destino)
    {
        if (destino == null)
            return false;

        _context.Destinos.Update(destino);
        destino.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
