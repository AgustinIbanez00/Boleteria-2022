namespace BoleteriaOnline.Web.Data.Models;
public class Pago
{
    public int Id { get; set; }
    public string Codigo { get; set; }
    public int Boleto { get; set; }
    public string Tipo { get; set; }
    public string Titular { get; set; }
    public long Dni { get; set; }
    public string Correo { get; set; }
    public string Tarjeta { get; set; }
    public long Nro_tarjeta { get; set; }
    public DateTime Fecha_vencimiento { get; set; }
    public int Precio { get; set; }
}
