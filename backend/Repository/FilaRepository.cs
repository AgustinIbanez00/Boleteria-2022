using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class FilaRepository : IFilaRepository
{
    private readonly ApplicationDbContext _context;

    public FilaRepository(ApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateFilaAsync(Fila fila)
    {
        if (fila == null)
            return false;

        _context.Filas.Update(fila);
        return await Save();
    }
}
