using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Data.Seeders;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data;
public class ApplicationDbContext : IdentityDbContext
{
    public virtual DbSet<Nodo> Nodos { get; set; }
    public virtual DbSet<Boleto> Boletos { get; set; }
    public virtual DbSet<Celda> Celdas { get; set; }
    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Usuario> Usuarios { get; set; }
    public virtual DbSet<Parada> Paradas { get; set; }
    public virtual DbSet<Distribucion> Distribuciones { get; set; }
    public virtual DbSet<Fila> Filas { get; set; }
    public virtual DbSet<Horario> Horarios { get; set; }
    public virtual DbSet<Pago> Pagos { get; set; }
    public virtual DbSet<Pais> Paises { get; set; }
    public virtual DbSet<Provincia> Provincias { get; set; }
    public virtual DbSet<Viaje> Viajes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Pais>().HasData(PaisSeeder.Paises);
        builder.Entity<Provincia>().HasData(ProvinciaSeeder.Provincias);

        base.OnModelCreating(builder);
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
