using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Repository;
public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;

    public UsuarioRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUsuarioAsync(Usuario usuario)
    {
        usuario.Id = 0;
        await _context.Usuarios.AddAsync(usuario);
        return await Save();
    }

    public async Task<bool> ExistsUsuarioAsync(int id) => await _context.Usuarios.AnyAsync(u => u.Id == id);
    public async Task<bool> ExistsUsuarioByEmailAsync(string email) => await _context.Usuarios.AnyAsync(u => u.Email == email);
    public async Task<bool> ExistsUsuarioByUserNameAsync(string userName) => await _context.Usuarios.AnyAsync(u => u.UserName == userName);
    public async Task<Usuario> GetUsuarioAsync(int id) => await _context.Usuarios.FindAsync(id);
    public async Task<ICollection<Usuario>> GetUsuariosAsync() => await _context.Usuarios.ToListAsync();
    public async Task<Usuario> GetUsuarioByEmailAsync(string email) => await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
    public async Task<Usuario> GetUsuarioByUserNameAsync(string userName) => await _context.Usuarios.FirstOrDefaultAsync(u => u.UserName == userName);
    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> LockUsuarioAsync(int id)
    {
        Usuario usuario = await GetUsuarioAsync(id);
        if (usuario == null)
            return false;

        usuario.LockoutEnabled = true;

        return await Save();
    }

}
