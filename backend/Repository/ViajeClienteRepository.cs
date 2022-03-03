using System.Linq.Expressions;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class ViajeClienteRepository : IViajeClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ViajeClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<bool> CreateAsync(Viaje entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Viaje entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(ViajeClienteFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(ViajeClienteFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<Viaje> FindAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Viaje>> GetAllAsync(ViajeClienteFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedList<Viaje>> GetAllPaginatedAsync(ViajeClienteFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<Viaje> GetAsync(ViajeClienteFilter filter)
    {
        throw new NotImplementedException();
    }

    public Expression<Func<Viaje, bool>> GetExpression(ViajeClienteFilter filter)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Save()
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Viaje entity)
    {
        throw new NotImplementedException();
    }
}
