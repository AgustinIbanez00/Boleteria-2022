using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Data.Models;
using BoleteriaOnline.Web.Extensions.Hashing;
using Microsoft.EntityFrameworkCore;

namespace BoleteriaOnline.Web.Data.Seeders;
public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (ApplicationDbContext context = new(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
        {
            context.Database.EnsureCreated();
            if (context.Database.IsRelational())
            {
                context.Database.Migrate();
            }

            context.SaveChanges();

            IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

            context.Clientes.AddRange(ClienteSeeder.Seed(50));
            context.Paradas.AddRange(ParadasSeeder.Seed(100));
            context.Distribuciones.AddRange(DistribucionSeeder.Seed(5));

            context.SaveChanges();

            string secretUser = configuration.GetValue("SECRET_USER", string.Empty);
            string secretPassword = configuration.GetValue("SECRET_PASSWORD", string.Empty);

            if (!string.IsNullOrEmpty(secretUser) && !string.IsNullOrEmpty(secretPassword))
            {
                HashedPassword hashedPassword = secretPassword.Hash();

                Usuario adminUser = new()
                {
                    Email = secretUser,
                    Tipo = UsuarioTipo.ADMIN,
                    Password = hashedPassword.Password,
                    Salt = hashedPassword.Salt,
                    CreatedAt = DateTime.Now,
                    Gender = Gender.NOTDEFINED
                };
                context.Usuarios.Add(adminUser);
            }

            context.SaveChanges();
        }
    }
}
