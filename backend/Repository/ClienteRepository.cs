using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Repositories;
using BoleteriaOnline.Web.Data.Filters;
using System.Linq.Expressions;
using LinqKit;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Extensions;

namespace BoleteriaOnline.Web.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Cliente entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.Id = 0;
        await _context.Clientes.AddAsync(entity);
        return await Save();
    }

    public async Task<bool> DeleteAsync(Cliente entity)
    {
        if (entity == null)
            return false;

        if (entity.Estado == Estado.Baja)
            return false;

        entity.Estado = Estado.Baja;
        return await Save();
    }

    public async Task<bool> DeleteAsync(ClienteFilter filter)
    {
        Cliente cliente = await GetAsync(filter);
        return await DeleteAsync(cliente);
    }
    public Task<bool> ExistsAsync(ClienteFilter filter)
    {
        return _context.Clientes.AnyAsync(GetExpression(filter));
    }

    public async Task<ICollection<Cliente>> GetAllAsync(ClienteFilter filter)
    {
        return await _context.Clientes.Where(GetExpression(filter)).ToListAsync();
    }

    public async Task<PaginatedList<Cliente>> GetAllPaginatedAsync(ClienteFilter filter)
    {
        return await PaggingExtensions.CreateAsync(_context.Clientes.Where(GetExpression(filter)), filter.Pagina, filter.RecordsPorPagina);
    }

    public async Task<Cliente> GetAsync(ClienteFilter filter)
    {
        return await _context.Clientes.FirstOrDefaultAsync(GetExpression(filter));
    }

    public async Task<Cliente> GetClienteAsync(long id) => await _context.Clientes.FirstOrDefaultAsync(m => m.Estado == Estado.Activo && m.Id == id);

    public Expression<Func<Cliente, bool>> GetExpression(ClienteFilter filter)
    {
        return PredicateBuilder.New<Cliente>()
            .And(p => !filter.Dni.HasValue || (filter.Dni.HasValue && p.Id == filter.Dni.Value))
            .And(p => string.IsNullOrEmpty(filter.Nombre) || (!string.IsNullOrEmpty(filter.Nombre) && p.Nombre.Contains(filter.Nombre)))
            .And(p => !filter.FechaNacimiento.HasValue || (filter.FechaNacimiento.HasValue && p.FechaNac == filter.FechaNacimiento.Value))
            .And(p => !filter.NacionalidadId.HasValue || (filter.NacionalidadId.HasValue && p.NacionalidadId == filter.NacionalidadId.Value))
            .And(p => !filter.Genero.HasValue || (filter.Genero.HasValue && p.Genero == filter.Genero.Value))
            .And(p => !filter.Estado.HasValue || (filter.Estado.HasValue && p.Estado == filter.Estado.Value))
        ;
    }

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Cliente entity)
    {
        if (entity == null || entity.Estado == Estado.Baja)
            return false;

        _context.Clientes.Update(entity);
        entity.UpdatedAt = DateTime.Now;
        return await Save();
    }

}
