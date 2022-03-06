namespace BoleteriaOnline.Web.Data.Models;
public class Pais
{
    public int Id { get; set; }
    [StringLength(150)]
    public string Nombre { get; set; }
    [StringLength(3)]
    public string Sigla { get; set; }
    public List<Provincia> Provincias { get; set; }
}
