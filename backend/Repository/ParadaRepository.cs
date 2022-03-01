﻿using Microsoft.EntityFrameworkCore;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Repositories;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Core.Extensions;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Core.ViewModels.Filters;

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

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Parada destino)
    {
        if (destino == null)
            return false;

        _context.Paradas.Update(destino);
        destino.UpdatedAt = DateTime.Now;
        return await Save();
    }

    public async Task<PaginatedList<Parada>> GetAllAsync(ParadaFilter parameteres)
    {
        IQueryable<Parada> dbSet = null;

        dbSet = _context.Paradas;

        if (parameteres.Id.HasValue)
            dbSet = dbSet.Where(p => p.Id == parameteres.Id.Value);
        if (!string.IsNullOrEmpty(parameteres.Nombre))
            dbSet = dbSet.Where(p => p.Nombre.Contains(parameteres.Nombre));
        if (parameteres.Estado.HasValue)
            dbSet = dbSet.Where(p => p.Estado == parameteres.Estado);

        return await PaggingExtensions.CreateAsync(dbSet, parameteres.Pagina, parameteres.RecordsPorPagina);
    }
}
