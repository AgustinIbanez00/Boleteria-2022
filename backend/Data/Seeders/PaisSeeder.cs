using BoleteriaOnline.Web.Data.Models;

namespace BoleteriaOnline.Web.Data.Seeders;

public class PaisSeeder
{
    public List<Pais> Paises => new List<Pais>()
    {
        new Pais()
        {
            Id = 1,
            Nombre = "Argentina",
            Sigla = "ARG",
        }


    };

}
