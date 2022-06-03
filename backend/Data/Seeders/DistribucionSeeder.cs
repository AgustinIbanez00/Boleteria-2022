using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Data.Seeders;

public class DistribucionSeeder
{
    public static List<Distribucion> Seed(int cant)
    {
        List<Distribucion> list = new();

        for (int i = 0; i < cant; i++)
        {
            bool unPiso = Faker.Boolean.Random();

            int maxRows = unPiso ? Faker.RandomNumber.Next(5, 10) : Faker.RandomNumber.Next(5, 25);

            List<Fila> rows = new();

            int spacing = Faker.RandomNumber.Next(1, 3);

            for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
            {
                Fila fila = new() { Cells = new List<Celda>() };
                fila.Planta = Faker.Enum.Random<Planta>();

                DistribucionEspacio tipoButaca = spacing switch
                {
                    1 => DistribucionEspacio.ESPACIO_BUTACA,
                    2 => DistribucionEspacio.ESPACIO_BUTACA_CAMA,
                    3 => DistribucionEspacio.ESPACIO_BUTACA_SEMICAMA,
                    _ => DistribucionEspacio.ESPACIO_PASILLO
                };

                for (int cellIndex = 0; cellIndex < 5; cellIndex++)
                {
                    fila.Cells.Add(new Celda() { Value = cellIndex != 0 && cellIndex != 4 && cellIndex % spacing == 0 ? DistribucionEspacio.ESPACIO_PASILLO : tipoButaca });
                }

                rows.Add(fila);
            }

            list.Add(
            new Distribucion()
            {
                Nota = Faker.Company.Name(),
                UnPiso = unPiso,
                Filas = rows
            });
        }
        return list;
    }
}

