using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class ViajeRepository : IViajeRepository
{
    private readonly ApplicationDbContext _context;

    public ViajeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateViajeAsync(Viaje viaje)
    {
        viaje.CreatedAt = DateTime.Now;
        viaje.Id = 0;
        await _context.Viajes.AddAsync(viaje);
        return await Save();
    }

    public async Task<bool> DeleteViajeAsync(long id)
    {
        Viaje viaje = await GetViajeAsync(id);
        return viaje == null ? false : await DeleteViajeAsync(viaje);
    }

    public async Task<bool> DeleteViajeAsync(Viaje viaje)
    {
        if (viaje == null)
            return false;

        _context.Viajes.Remove(viaje);
        return await Save();
    }

    public async Task<bool> ExistsViajeAsync(long id) => await _context.Viajes.AnyAsync(e => e.Id == id);

    public async Task<Viaje> GetViajeAsync(long id) => await _context.Viajes.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<ICollection<Viaje>> GetViajesAsync() => await _context.Viajes.ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateViajeAsync(Viaje viaje)
    {
        if (viaje == null)
            return false;

        _context.Viajes.Update(viaje);
        viaje.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
