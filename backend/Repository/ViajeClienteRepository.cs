using BoleteriaOnline.Core.ViewModels;
using BoleteriaOnline.Core.ViewModels.Filters;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Extensions;
using BoleteriaOnline.Web.Repositories;

namespace BoleteriaOnline.Web.Repository;

public class ViajeClienteRepository : IViajeClienteRepository
{
    private readonly ApplicationDbContext _context;

    public ViajeClienteRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<ViajeClienteDTO>> GetAllAsync(ViajeClienteFilter filter)
    {
        return await _context.LoadStoredProc("BuscarBoletos")
                .WithSqlParam("OrigenId", filter.OrigenId)
                .WithSqlParam("DestinoId", filter.DestinoId)
                .WithSqlParam("Fecha", filter.Fecha)
                .ExecuteStoredProc<ViajeClienteDTO>();
    }

}

