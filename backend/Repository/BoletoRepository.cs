using System.Linq.Expressions;
using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Core.ViewModels.Pagging;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Repository;

public class BoletoRepository : IBoletoRepository
{
    private readonly ApplicationDbContext _context;

    public BoletoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateAsync(Boleto entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.Estado = BoletoEstado.RESERVADO;
        await _context.Boletos.AddAsync(entity);
        return await Save();
    }

    public async Task<bool> DeleteAsync(Boleto entity)
    {
        if (entity == null)
        {
            return false;
        }

        _context.Boletos.Remove(entity);

        return await Save();
    }

    public async Task<bool> DeleteAsync(BoletoFilter filter)
    {
        Boleto boleto = await GetAsync(filter);
        return await DeleteAsync(boleto);
    }
    public Task<bool> ExistsAsync(BoletoFilter filter)
    {
        return _context.Boletos.AnyAsync(GetExpression(filter));
    }

    public async Task<Boleto> FindAsync(int id)
    {
        return await _context.Boletos.FindAsync(id);
    }

    public async Task<ICollection<Boleto>> GetAllAsync(BoletoFilter filter)
    {
        return await _context.Boletos.Where(GetExpression(filter)).ToListAsync();
    }

    public async Task<PaginatedList<Boleto>> GetAllPaginatedAsync(BoletoFilter filter)
    {
        return await PaggingExtensions.CreateAsync(_context.Boletos.Where(GetExpression(filter)), filter.Pagina, filter.RecordsPorPagina);
    }

    public async Task<Boleto> GetAsync(BoletoFilter filter)
    {
        return await _context.Boletos.FirstOrDefaultAsync(GetExpression(filter));
    }

    public Expression<Func<Boleto, bool>> GetExpression(BoletoFilter filter)
    {
        return PredicateBuilder.New<Boleto>()
            .And(p => !filter.Id.HasValue || (filter.Id.HasValue && p.Id == filter.Id.Value))
            .And(p => !filter.RecorridoId.HasValue || (filter.RecorridoId.HasValue && p.RecorridoId == filter.RecorridoId.Value))
            .And(p => !filter.OrigenId.HasValue || (filter.OrigenId.HasValue && p.OrigenId == filter.OrigenId.Value))
            .And(p => !filter.DestinoId.HasValue || (filter.DestinoId.HasValue && p.DestinoId == filter.DestinoId.Value))
            .And(p => !filter.PasajeroId.HasValue || (filter.PasajeroId.HasValue && p.PasajeroId == filter.PasajeroId.Value))
            //.And(p => !filter.PagoId.HasValue || (filter.PagoId.HasValue && p.PagoId == filter.PagoId.Value))
            .And(p => !filter.Asiento.HasValue || (filter.Asiento.HasValue && p.Asiento == filter.Asiento.Value))
            .And(p => !filter.Precio.HasValue || (filter.Precio.HasValue && p.Precio == filter.Precio.Value))
            .And(p => string.IsNullOrEmpty(filter.HoraSalida) || (!string.IsNullOrEmpty(filter.HoraSalida) && p.HoraSalida.Contains(filter.HoraSalida)))
            .And(p => string.IsNullOrEmpty(filter.HoraLlegada) || (!string.IsNullOrEmpty(filter.HoraLlegada) && p.HoraSalida.Contains(filter.HoraLlegada)))
            .And(p => !filter.Estado.HasValue || (filter.Estado.HasValue && p.Estado == filter.Estado.Value))
            .And(p => !filter.Fecha.HasValue || (filter.Fecha.HasValue && p.Fecha == filter.Fecha.Value))
            ;
    }

    public async Task<bool> Save() => await _context.SaveChangesAsync() >= 0;

    public async Task<bool> UpdateAsync(Boleto entity)
    {
        if (entity == null)
        {
            return false;
        }

        _context.Boletos.Update(entity);
        entity.UpdatedAt = DateTime.Now;
        return await Save();
    }

}

