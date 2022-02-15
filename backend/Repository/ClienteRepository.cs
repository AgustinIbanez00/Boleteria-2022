using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateClienteAsync(Cliente cliente)
    {
        cliente.CreatedAt = DateTime.Now;
        cliente.Id = 0;
        await _context.Clientes.AddAsync(cliente);
        return await Save();
    }

    public async Task<bool> DeleteClienteAsync(long id)
    {
        Cliente cliente = await GetClienteAsync(id);
        return await DeleteClienteAsync(cliente);
    }

    public async Task<bool> DeleteClienteAsync(Cliente cliente)
    {
        if (cliente == null)
            return false;

        if (cliente.Estado == Estado.Baja)
            return false;

        cliente.Estado = Estado.Baja;
        return await Save();
    }

    public async Task<bool> ExistsClienteAsync(long id) => await _context.Clientes.AnyAsync(e => e.Estado == Estado.Activo && e.Id == id);

    public async Task<Cliente> GetClienteAsync(long id) => await _context.Clientes.FirstOrDefaultAsync(m => m.Estado == Estado.Activo && m.Id == id);

    public async Task<ICollection<Cliente>> GetClientesAsync() => await _context.Clientes.Where(m => m.Estado == Estado.Activo).ToListAsync();

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateClienteAsync(Cliente cliente)
    {
        if (cliente == null || cliente.Estado == Estado.Baja)
            return false;

        _context.Clientes.Update(cliente);
        cliente.UpdatedAt = DateTime.Now;
        return await Save();
    }
}
