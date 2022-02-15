using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository
{
    public class CeldaRepository : ICeldaRepository
    {
        private readonly ApplicationDbContext _context;

        public CeldaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

        public async Task<bool> UpdateCeldaAsync(Celda celda)
        {
            if (celda == null)
                return false;

            _context.Celdas.Update(celda);
            return await Save();
        }
    }
}
