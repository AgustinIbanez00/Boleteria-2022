using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Data.Seeders;
public class ClienteSeeder
{
    public static List<Cliente> Seed(int cant)
    {
        var list = new List<Cliente>();

        for (int i = 0; i < cant; i++)
        {
            list.Add
                (new Cliente()
                {
                    Id = Faker.RandomNumber.Next(9999999),
                    Genero = Faker.Enum.Random<Gender>(),
                    FechaNac = Faker.Identification.DateOfBirth(),
                    Estado = Faker.Boolean.Random() ? Estado.Activo : Estado.Baja,
                    Nombre = $"{Faker.Name.First()} {Faker.Name.Last()}"  ,
                });
        }
        return list;
    }

}
