using BoleteriaOnline.Core.Data.Enums;
using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Data.Seeders;

public class DistribucionSeeder
{
    public static List<Distribucion> Seed(int cant)
    {
        var list = new List<Distribucion>();

        for (int i = 0; i < cant; i++)
        {
            var unPiso = Faker.Boolean.Random();

            var maxRows = unPiso ? Faker.RandomNumber.Next(5, 10) : Faker.RandomNumber.Next(5, 25);

            var rows = new List<Fila>();

            var spacing = Faker.RandomNumber.Next(1, 3);

            for (int rowIndex = 0; rowIndex < maxRows; rowIndex++)
            {
                var fila = new Fila() { Cells = new List<Celda>()};
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

