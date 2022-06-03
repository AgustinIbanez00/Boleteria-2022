using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Data.Seeders;

public class ParadasSeeder
{
    public static List<Parada> Seed(int cant)
    {
        var list = new List<Parada>();

        for (int i = 0; i < cant; i++)
        {
            list.Add
                (new Parada()
                {
                     Nombre = Faker.Address.City(),
                     PaisId = 32,
                     ProvinciaId = Faker.RandomNumber.Next(2, 25),
                     Estado = Faker.Boolean.Random() ? Core.Data.Enums.Estado.Activo : Core.Data.Enums.Estado.Baja,
                     CreatedAt = DateTime.Now,
                     UpdatedAt = DateTime.Now
                });
        }
        return list;
    }
}

