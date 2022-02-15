using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class DistribucionRepository : IDistribucionRepository
{
    private readonly ApplicationDbContext _context;

    public DistribucionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateDistribucionAsync(Distribucion distribucion)
    {
        distribucion.CreatedAt = DateTime.Now;
        distribucion.Id = 0;
        await _context.Distribuciones.AddAsync(distribucion);
        return await Save();
    }

    public async Task<bool> DeleteDistribucionAsync(long id)
    {
        Distribucion distribucion = await GetDistribucionAsync(id);
        return distribucion == null ? false : await DeleteDistribucionAsync(distribucion);
    }

    public async Task<bool> DeleteDistribucionAsync(Distribucion distribucion)
    {
        if (distribucion == null)
            return false;

        _context.Distribuciones.Remove(distribucion);
        return await Save();
    }

    public async Task<bool> ExistsDistribucionAsync(long id) => await _context.Distribuciones.AnyAsync(e => e.Id == id);

    public async Task<Distribucion> GetDistribucionAsync(long id)
    {
        return await _context.Distribuciones
            .Include(d => d.Filas.OrderBy(f => f.Id))
            .ThenInclude(d => d.Cells.OrderBy(c => c.Id))
            .FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task<ICollection<Distribucion>> GetDistribucionesAsync()
    {
        return await _context.Distribuciones.ToListAsync();
    }

    public async Task<bool> RemoveAllFilas(Distribucion distribucion)
    {
        foreach (var fila in distribucion.Filas)
        {
            foreach (var celda in fila.Cells)
            {
                await _context.Celdas.Where(c => c.FilaId == fila.Id).DeleteFromQueryAsync();
            }
        }

        var rows = await _context.Filas.Where(f => f.DistribucionId == distribucion.Id).DeleteFromQueryAsync();

        return rows > 0;
    }

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateDistribucionAsync(Distribucion distribucion)
    {
        if (distribucion == null)
            return false;

        _context.Distribuciones.Update(distribucion);
        distribucion.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
